using FPL.Dal.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FPL.Api.Controllers
{
    public class ReviewSubmissionController : ApiController
    {
        private JournalManagementPortalEntities db = new JournalManagementPortalEntities();

        [HttpPost]
        public async Task<IHttpActionResult> saveReviewers(reviewersDataModel data)
        {
            try
            {
                var manuscriptID = db.ManuscriptSubs.Where(c => c.ManuscriptNo == data.ManuscriptNo).Select(c => c.id).FirstOrDefault();
                var reviewer1 = data.Reviewer1;
                var reviewer1ID = Convert.ToInt32(reviewer1);
                var reviewer1Name = db.Register_Table.Where(c => c.RegisterID == reviewer1ID).Select(c => c.FullName).FirstOrDefault();
                var reviewer2 = data.Reviewer2;
                var reviewer2ID = Convert.ToInt32(reviewer2);
                var reviewer2Name = db.Register_Table.Where(c => c.RegisterID == reviewer2ID).Select(c => c.FullName).FirstOrDefault();
                var reviewer3 = data.Reviewer3;
                var reviewer3ID = Convert.ToInt32(reviewer3);
                var reviewer3Name = db.Register_Table.Where(c => c.RegisterID == reviewer3ID).Select(c => c.FullName).FirstOrDefault();

                var authorID = db.ManuscriptSubs.Where(c => c.ManuscriptNo == data.ManuscriptNo).Select(c => c.RegisterID).FirstOrDefault();
                var authorName = db.ManuscriptSubs.Where(c => c.RegisterID == authorID).Select(c => c.AuthorName).FirstOrDefault();

                var manuscriptSubmittedDate = db.ManuscriptSubs.Where(c => c.ManuscriptNo == data.ManuscriptNo).Select(c => c.CreatedOn).FirstOrDefault();

                var subjectID = db.subjectcontent_Table.Where(c => c.SubjectName == data.Subject).Select(c => c.SubjectID).FirstOrDefault();

                Table_SubmissionForReview reviewersList = new Table_SubmissionForReview()
                {
                    Reviewer1 = reviewer1Name,
                    ManuscriptNo = data.ManuscriptNo,
                    Subject = data.Subject,
                    Title = data.Title,
                    CreatedOn = DateTime.Now,
                    ManuscriptName = data.manuscriptPDFName,
                    ManuscriptID = manuscriptID,
                    ManuscriptPDF = data.ManuscriptPDF,
                    AuthorID = authorID,
                    AuthorName = authorName, 
                    ManuscriptSubmittedDate = manuscriptSubmittedDate,
                    SubjectID = subjectID,
                    UndertakingForm = data.undertakingdocurl,
                    PlagiarismReport = data.plagiarismurl,
                    ReviewerID = reviewer1ID,
                    ReviewerName = reviewer1Name,
                    SentForReviewDate = DateTime.Now
                };

                db.Table_SubmissionForReview.Add(reviewersList);
                Table_SubmissionForReview reviewersList2 = new Table_SubmissionForReview()
                {
                    Reviewer2 = reviewer2Name,
                    ManuscriptNo = data.ManuscriptNo,
                    Subject = data.Subject,
                    Title = data.Title,
                    CreatedOn = DateTime.Now,
                    ManuscriptName = data.manuscriptPDFName,
                    ManuscriptID = manuscriptID,
                    ManuscriptPDF = data.ManuscriptPDF,
                    AuthorID = authorID,
                    AuthorName = authorName,
                    ManuscriptSubmittedDate = manuscriptSubmittedDate,
                    SubjectID = subjectID,
                    UndertakingForm = data.undertakingdocurl,
                    PlagiarismReport = data.plagiarismurl,
                    ReviewerID = reviewer2ID,
                    ReviewerName = reviewer2Name,
                    SentForReviewDate = DateTime.Now

                };

                db.Table_SubmissionForReview.Add(reviewersList2);

                Table_SubmissionForReview reviewersList3 = new Table_SubmissionForReview()
                {
                    Reviewer3 = reviewer3Name,
                    ManuscriptNo = data.ManuscriptNo,
                    Subject = data.Subject,
                    Title = data.Title,
                    CreatedOn = DateTime.Now,
                    ManuscriptName = data.manuscriptPDFName,
                    ManuscriptID = manuscriptID,
                    ManuscriptPDF = data.ManuscriptPDF,
                    AuthorID = authorID,
                    AuthorName = authorName,
                    ManuscriptSubmittedDate = manuscriptSubmittedDate,
                    SubjectID = subjectID,
                    UndertakingForm = data.undertakingdocurl,
                    PlagiarismReport = data.plagiarismurl,
                    ReviewerID = reviewer3ID,
                    ReviewerName = reviewer3Name,
                    SentForReviewDate = DateTime.Now

                };

                db.Table_SubmissionForReview.Add(reviewersList3);

                db.SaveChanges();

                return Ok("success");
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }

    public class reviewersDataModel
    {
        public int Id { get; set; }
        public string ManuscriptNo { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public string Subject { get; set; }
        public string Title { get; set; }
        public Nullable<int> ManuscriptID { get; set; }
        public string manuscriptPDFName { get; set; }
        public string plagiarismurl { get; set; }
        public string undertakingdocurl { get; set; }
        public string ManuscriptPDF { get; set; }
        public Nullable<int> AuthorID { get; set; }
        public string AuthorName { get; set; }
        public Nullable<int> ReviewerID { get; set; }
        public string ReviewerName { get; set; }
        public Nullable<System.DateTime> ManuscriptSubmittedDate { get; set; }
        public Nullable<System.DateTime> SentForReviewDate { get; set; }
        public Nullable<bool> IsReviewComplete { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string Reviewer1 { get; set; }
        public string Reviewer2 { get; set; }
        public string Reviewer3 { get; set; }
    }
}
