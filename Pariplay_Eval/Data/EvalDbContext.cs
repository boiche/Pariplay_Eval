using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pariplay_Eval.Data.Configurations;
using Pariplay_Eval.Data.Events;
using System.Text.RegularExpressions;

namespace Pariplay_Eval.Data
{
    public class EvalDbContext : DbContext
    {
        internal event MatchAdded.MatchAddedHandler MatchAdded;
        public EvalDbContext(DbContextOptions<EvalDbContext> options) : base(options) 
        {
            MatchAdded += UpdateStanding;
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<League> Leagues { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new LeagueConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        internal void RaiseMatchAdded(object sender, MatchAddedArgs args)
        {
            MatchAdded.Invoke(sender, args);
        }

        internal void UpdateStanding(object sender, MatchAddedArgs args)
        {
            var standingToUpdate = Leagues.First(x => x.Id == args.Match.LeagueId);
            List<Standing> standings = JsonConvert.DeserializeObject<List<Standing>>(standingToUpdate.Data) ?? new List<Standing>();
            Team homeTeam = Teams.First(x => x.Id == args.Match.HomeTeamId);
            Team awayTeam = Teams.First(x => x.Id == args.Match.AwayTeamId);
            Standing homeTeamStanding = standings.FirstOrDefault(x => x.TeamName == homeTeam.Name);
            if (homeTeamStanding is null)
            {
                homeTeamStanding = new Standing()
                {
                    TeamName = homeTeam.Name,
                };
                standings.Add(homeTeamStanding);
            }
            Standing awayTeamStanding = standings.FirstOrDefault(x => x.TeamName == awayTeam.Name);
            if (awayTeamStanding is null)
            {
                awayTeamStanding = new Standing()
                {
                    TeamName = awayTeam.Name,
                };
                standings.Add(awayTeamStanding);
            }
            homeTeamStanding.PlayedGames++;
            awayTeamStanding.PlayedGames++;

            if (args.Match.HomeScore > args.Match.AwayScore)
            {
                homeTeamStanding.Victories++;
                awayTeamStanding.Defeats++;
                homeTeamStanding.Points += 3;
            }
            else if (args.Match.HomeScore < args.Match.AwayScore)
            {
                awayTeamStanding.Victories++;
                homeTeamStanding.Defeats++;
                awayTeamStanding.Points += 3;
            }
            else
            {
                homeTeamStanding.Draws++;
                awayTeamStanding.Draws++;
                homeTeamStanding.Points++;
                awayTeamStanding.Points++;
            }

            homeTeamStanding.GoalDifference += (args.Match.HomeScore - args.Match.AwayScore);
            awayTeamStanding.GoalDifference += (args.Match.AwayScore - args.Match.HomeScore);

            standings.OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalDifference)
                .ThenBy(x => x.PlayedGames)
                .ToList();

            standingToUpdate.Data = JsonConvert.SerializeObject(standings, Formatting.Indented);
            SaveChanges();
        }
    }
}
