#include "Appointment.h"
#include <list>
#include "Bill.h"

using namespace std;

class AppointmentManager {
    public:
        void loadServices();
        void loadAppointments();
        void saveAppointments() const;
        void displayAppointments() const;
        void bookAppointment(const char* customerName, int age, const char* appointmentTime, const char* date, const char* phoneNumber, const char* IDcardnumber);
        void cancelAppointment(const char* IDcardnumber);

        bool generateBillAndMarkAsCompleted(const char* IDcardnumber);

        void exportAppointmentsByDate(const char* date) const;

    private:
        list<Appointment> appointments;
        list<Service> availableServices;
        list<Bill> bills;
};