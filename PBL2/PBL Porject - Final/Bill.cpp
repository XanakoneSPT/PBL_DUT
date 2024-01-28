#include "Bill.h"
#include "Service.h"
#include "Appointment.h"
#include <iostream>
#include <cstring>
#include <fstream>

using namespace std;

Bill::Bill(const char* customer, const char* time, double cost, const list<Service>& services)
    : totalCost(cost), services(services) {
    strncpy(customerName, customer, sizeof(customerName) - 1);
    customerName[sizeof(customerName) - 1] = '\0';

    strncpy(appointmentTime, time, sizeof(appointmentTime) - 1);
    appointmentTime[sizeof(appointmentTime) - 1] = '\0';
}

double Bill::calculateTotalCost(const Appointment& appointment) const {
    double totalCost = 0.0;

    for (const Service& service : services) {
        int serviceValue = service.getValue();

        switch (serviceValue) {
            case 1: // HairCut
                totalCost += 15.0;
                break;
            case 2: // WashHair
                totalCost += 10.0;
                break;
            case 3: // BeardShave
                totalCost += 8.0;
                break;
            case 4: // FaceMassage
                totalCost += 20.0;
                break;
            case 5: // CleanEars
                totalCost += 12.0;
                break;
            default:
                // Handle unknown service or other cases here
                break;
        }
    }
    return totalCost;
}

void Bill::generateBillForCustomer(const char* IDcardnumber, const list<Appointment>& appointments) const {
    for (const Appointment& appointment : appointments) {
        if (strcmp(appointment.getIDcardNum(), IDcardnumber) == 0) {
            double totalCost = calculateTotalCost(appointment);
            cout << "\n\n\n";
            cout << "===============================================================================" << endl;
            cout << "\t\t\t Hair Cut Shop Bill." << endl;
            cout << "===============================================================================" << endl;
            cout << endl;

            cout << "\tID: " << IDcardnumber << endl;
            cout << "\tCustomer Name: " << customerName << endl;
            cout << "\tAppointment Time: " << appointmentTime << endl;
            cout << "\tAppointment Date: " << appointment.getDate() << endl;
            cout << endl;

            cout << "\tServices: ";
            bool firstService = true;
            for (const Service& service : services) {
                if (!firstService) {
                    cout << ", ";
                }
                cout << ServiceToString(service);
                firstService = false;
            }
            cout << ".";

            cout << "\n\n" << "\tTotal Cost: $" << totalCost << endl;
            cout << endl;
            cout << "===============================================================================" << endl;
            cout << "\n\n";
        }
    }

        string filename = "Bill_" + string(IDcardnumber) + ".txt";  // Corrected file extension

    ofstream file(filename);  // Open the file for writing

    if (file.is_open()) {
        for (const Appointment& appointment : appointments) {
            if (strcmp(appointment.getIDcardNum(), IDcardnumber) == 0) {
                double totalCost = calculateTotalCost(appointment);

                file << "===============================================================================" << endl;
                file << "\t\t\t Hair Cut Shop Bill." << endl;
                file << "===============================================================================" << endl;
                file << endl;

                file << "\tID Card: " << appointment.getIDcardNum() << endl;
                file << "\tCustomer Name: " << appointment.getCustomerName() << endl;
                file << "\tAppointment Time: " << appointment.getAppointmentTime() << endl;
                file << "\tAppointment Date: " << appointment.getDate() << endl;
                file << endl;

                file << "\tServices: ";
                bool firstService = true;
                for (const Service& service : appointment.getServices()) {
                    if (!firstService) {
                        file << ", ";
                    }
                    file << ServiceToString(service);
                    firstService = false;
                }
                file << ".";

                file << "\n\n" << "\tTotal Cost: $" << totalCost << endl;
                file << endl;
                file << "===============================================================================" << endl;
                cout << "\n\n";

                cout << "Bill exported to: " << filename << endl;
                system("pause");
                return;
            }
        }
    } else {
        cout << "Error opening file: " << filename << endl;
    }

    cout << "No appointment found for ID: " << IDcardnumber << endl;
}
