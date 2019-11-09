using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection connection =
                new SqlConnection(@"Data Source=CSHARPHUMBER\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;");

            using (connection)
            {
                connection.Open();

                string query = "select * from Applicant_Educations";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;

                ApplicantEducation[] applicantEducations =
                    new ApplicantEducation[1000];
                int index = 0;

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    ApplicantEducation edu = new ApplicantEducation();
                    edu.Id = (Guid)reader["Id"];
                    edu.Applicant = (Guid)reader["Applicant"];
                    edu.Major = (string)reader["Major"];
                    edu.StartDate = (DateTime)reader["Start_Date"];

                    applicantEducations[index] = edu;
                    index++;
                }

            }

        }
    }

    class ApplicantEducation
    {
        public Guid Id;
        public Guid Applicant;
        public string Major;
        public DateTime StartDate;
    }
}
