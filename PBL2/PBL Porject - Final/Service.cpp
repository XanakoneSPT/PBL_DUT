#include "Service.h"
#include <cstring>

Service::Service(int value, const char* ServiceName) : value(value) {
    this->ServiceName = new char[strlen(ServiceName) + 1];
    strcpy(this->ServiceName, ServiceName);
}

int Service::getValue() const {
    return value;
}

const char* Service::getName() const {
    return ServiceName;
}

void Service::setName(const char* ServiceName) {
    this->ServiceName = new char[strlen(ServiceName) + 1];
    strcpy(this->ServiceName, ServiceName);
}

const char* ServiceToString(const Service& service) {
    switch (service.getValue()) {
        case 1:
            return "Haircut";
        case 2:
            return "WashHair";
        case 3:
            return "BeardShave";
        case 4:
            return "FaceMassage";
        case 5:
            return "CleanEars";
        default:
            return "UnknownService";
    }
}
