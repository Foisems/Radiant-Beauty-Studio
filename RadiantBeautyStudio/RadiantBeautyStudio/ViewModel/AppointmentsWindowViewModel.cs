using RadiantBeautyStudio.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantBeautyStudio.ViewModel
{
    public class AppointmentsWindowViewModel : BaseViewModel
    {
        ObservableCollection<AppointmentsList> appointmentsLists = new ObservableCollection<AppointmentsList>();
        public ObservableCollection<AppointmentsList> AppointmentsLists
        {
            get => appointmentsLists;
            set
            {
                appointmentsLists = value;
                OnPropertyChanged(nameof(AppointmentsLists));
            }
        }

        public AppointmentsWindowViewModel()
        {
            UpdateList();
        }

        public void UpdateList()
        {
            using (BeautyStudioDBEntities db = new BeautyStudioDBEntities())
            {
                AppointmentsLists.Clear();
                foreach (var app in db.Appointment.ToList())
                {
                    AppointmentsLists.Add(new AppointmentsList(app));
                }
            }
        }
    }
}
