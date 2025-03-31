#include <list>
#include "Service.h"
#include "Appointment.h"

#pragma once

using namespace std;

class Bill {
    public:
        Bill(const char* customer, const char* time, double cost, const list<Service>& services);
        double calculateTotalCost(const Appointment& appointment) const;
        void generateBillForCustomer(const char* IDcardnumber, const list<Appointment>& appointments) const;

    private:
        char customerName[50];
        char appointmentTime[10];
        list<Service> services;
        double totalCost;
};