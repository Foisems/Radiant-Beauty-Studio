using RadiantBeautyStudio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantBeautyStudio.ViewModel
{
    public partial class AppointmentsList
    {
        public AppointmentsList(Appointment app)
        {
            this.Date = app.Date;
            using (BeautyStudioDBEntities db = new BeautyStudioDBEntities())
            {
                this.ClientName = db.Client.FirstOrDefault(c => c.Id == app.IdClient).FirstName + " " + db.Client.FirstOrDefault(c => c.Id == app.IdClient).Surname;
                this.ClientFirstName = db.Client.FirstOrDefault(c => c.Id == app.IdClient).FirstName;
                this.ClientSurname = db.Client.FirstOrDefault(c => c.Id == app.IdClient).Surname;
                this.ClientPatronymic = db.Client.FirstOrDefault(c => c.Id == app.IdClient).Patronymic;
                this.ClientPhone = db.Client.FirstOrDefault(c => c.Id == app.IdClient).PhoneNumber;

                this.ServiceName = db.Service.FirstOrDefault(c => c.Id == app.IdService).Name;

                this.StafferName = db.Staffer.FirstOrDefault(c => c.Id == app.IdStaffer).FirstName + " " + db.Staffer.FirstOrDefault(c => c.Id == app.IdStaffer).Surname;
                this.StafferFirstName = db.Staffer.FirstOrDefault(c => c.Id == app.IdStaffer).FirstName;
                this.StafferSurname = db.Staffer.FirstOrDefault(c => c.Id == app.IdStaffer).Surname;
                this.StafferPatronymic = db.Staffer.FirstOrDefault(c => c.Id == app.IdStaffer).Patronymic;
            }
        }
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPatronymic { get; set; }
        public string ClientPhone { get; set; }
        public string ServiceName { get; set; }
        public string StafferName { get; set; }
        public string StafferFirstName { get; set; }
        public string StafferSurname { get; set; }
        public string StafferPatronymic { get; set; }

    }
}
