#include "Appointment.h"
#include "iomanip"
#include <list>
#include <cstring>

using namespace std;

Appointment::Appointment(const char* customerName, const char* appointmentTime, const char *date, Service service, const char* IDcardnumber)
    : service(service), completed(false)
{ // Initialize service directly
    this->customerName = new char[strlen(customerName) + 1];
    strcpy(this->customerName, customerName);

    this->appointmentTime = new char[strlen(appointmentTime) + 1];
    strcpy(this->appointmentTime, appointmentTime);

    this->date = new char[strlen(date) + 1];
    strcpy(this->date, date);

    this->IDcardnumber = new char[strlen(IDcardnumber) + 1];
    strcpy(this->IDcardnumber, IDcardnumber);
}

Appointment::Appointment(const char* customerName, const char* appointmentTime, const char* date, const list<Service>& services, const char* IDcardnumber)
    : service(service), completed(false)
{
    this->customerName = new char[strlen(customerName) + 1];
    strcpy(this->customerName, customerName);

    this->appointmentTime = new char[strlen(appointmentTime) + 1];
    strcpy(this->appointmentTime, appointmentTime);

    this->date = new char[strlen(date) + 1];
    strcpy(this->date, date);

    this->IDcardnumber = new char[strlen(IDcardnumber) + 1];
    strcpy(this->IDcardnumber, IDcardnumber);

    this->services = services;
}

Appointment::~Appointment() {

}

const char* Appointment::getIDcardNum() const {
    return IDcardnumber;
}

void Appointment::setIDnumber(const char* IDcardnumber) {

    this->IDcardnumber = new char[strlen(IDcardnumber) + 1];
    strcpy(this->IDcardnumber, IDcardnumber);
}

const char* Appointment::getCustomerName() const {
    return customerName;
}

const char* Appointment::getAppointmentTime() const {
    return appointmentTime;
}

const char* Appointment::getDate() const {
    return date;
}

const list<Service>& Appointment::getServices() const {
    return services;
}

bool Appointment::isCompleted() const {
    return completed;
}

void Appointment::setCompleted(bool status) {
    completed = status;
}

const char* Appointment::serialize() const {
    stringstream ss;
    ss << customerName << "," << appointmentTime << "," << date << "," << IDcardnumber << "," << completed << ",";

    bool firstService = true;
    for (const Service& service : services) {
        if (!firstService) {
            ss << " ";
        }
        ss << service.getValue(); // Use getValue() method to get the integer value
        firstService = false;
    }

    string result = ss.str();
    char* serializedData = new char[result.length() + 1];
    strcpy(serializedData, result.c_str());

    return serializedData;
}
