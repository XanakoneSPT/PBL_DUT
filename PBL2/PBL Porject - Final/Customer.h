#pragma once

class Customer {
    public:
        Customer(const char* name,int age, const char* phoneNumber, const char* IDcardnumber);

        // Function to save customer information to a file
        void saveCustomerInfo() const;

    private:
        char* name;
        int age;
        char* phoneNumber;
        char* IDcardnumber;
};