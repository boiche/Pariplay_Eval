using Microsoft.EntityFrameworkCore;
using Pariplay_Eval.Data.Configurations;
using Pariplay_Eval.Data.Events;

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
        public DbSet<Standing> Standings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new StandingConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        internal void RaiseMatchAdded(object sender, MatchAddedArgs args)
        {
            MatchAdded.Invoke(sender, args);
        }

        internal void UpdateStanding(object sender, MatchAddedArgs args)
        {
            Team homeTeam = Teams.First(x => x.Id == args.Match.HomeTeamId);
            Team awayTeam = Teams.First(x => x.Id == args.Match.AwayTeamId);
            Standing? homeTeamStanding = Standings.FirstOrDefault(x => x.TeamId == args.Match.HomeTeamId && x.LeagueName == args.Match.LeagueName);
            if (homeTeamStanding is null)
            {
                homeTeamStanding = new Standing()
                {
                    LeagueName = args.Match.LeagueName,
                    Team = new() 
                    { 
                        Name = homeTeam.Name,                        
                    }
                };
                Standings.Add(homeTeamStanding);
            }
            Standing? awayTeamStanding = Standings.FirstOrDefault(x => x.TeamId == args.Match.AwayTeamId && x.LeagueName == args.Match.LeagueName);
            if (awayTeamStanding is null)
            {
                awayTeamStanding = new Standing()
                {
                    LeagueName = args.Match.LeagueName,
                    Team = new() 
                    { 
                        Name = awayTeam.Name 
                    },
                };
                Standings.Add(awayTeamStanding);
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

            SaveChanges();
        }
    }
}
