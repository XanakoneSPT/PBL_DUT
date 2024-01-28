#pragma once

class Service {
    public:
        Service(int value, const char* ServiceName);
        void setName(const char* ServiceName);
        const char* getName() const;
        int getValue() const;

    private:
        int value;
        char* ServiceName;  // Adjust the size based on your requirement
};

const char* ServiceToString(const Service& service);
