using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTracker.Data
{
    public class CandidateRepository
    {
        private string _connectionString;

        public CandidateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddCandidate(Candidate candidate)
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                context.Candidates.InsertOnSubmit(candidate);
                context.SubmitChanges();
            }
        }
        public IEnumerable<Candidate> GetPending()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == CandidateTracker.Data.Status.Pending).ToList();
            }
        }
        public IEnumerable<Candidate> GetConfirmed()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == CandidateTracker.Data.Status.Confirmed).ToList();
            }
        }
        public IEnumerable<Candidate> GetDeclined()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == CandidateTracker.Data.Status.Declined).ToList();
            }
        }

        public Candidate ViewCandidateDetails(int id)
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.FirstOrDefault(p => p.Id == id);
            }
        }
        public int GetPendingCount()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == CandidateTracker.Data.Status.Pending).Count();
            }
        }
        public int GetConfirmedCount()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == CandidateTracker.Data.Status.Confirmed).Count();
            }
        }
        public int GetDeclinedCount()
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                return context.Candidates.Where(c => c.Status == CandidateTracker.Data.Status.Declined).Count();
            }
        }
        public void SetConfirmedStatus(int id)
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                context.ExecuteCommand("UPDATE Candidates SET Status = 1  WHERE Id = {0}", id);
            }
        }

        public void SetDeclinedStatus(int id)
        {
            using (var context = new CandidatesDataContext(_connectionString))
            {
                context.ExecuteCommand("UPDATE Candidates SET Status = 2  WHERE Id = {0}", id);
            }
        }
    }
}
