#include <list>
#include "Service.h"
#pragma once

using namespace std;

class Appointment {
    public:
        Appointment(const char* customerName, const char* appointmentTime, const char* date, Service service, const char* IDcardnumber);
        Appointment(const char* customerName, const char* appointmentTime, const char* date, const list<Service>& services, const char* IDcardnumber);
        ~Appointment();
        const char* getCustomerName() const;
        const char* getAppointmentTime() const;
        const char* getDate() const;
        Service getService() const;
        const list<Service>& getServices() const;
        const char* serialize() const;

        const char* getIDcardNum() const;
        void setIDnumber(const char* IDcardnumber);

        bool isCompleted() const;
        void setCompleted(bool status);

    private:
        char* customerName;
        char* appointmentTime;
        char* date;
        Service service;
        list<Service> services;

        bool completed;
        char* IDcardnumber;
};
