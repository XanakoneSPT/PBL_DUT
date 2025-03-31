#include "Customer.h"
#include <iostream>
#include <fstream>
#include <cstring>
#include <iomanip>

using namespace std;

Customer::Customer(const char* name, int age, const char* phoneNumber, const char* IDcardnumber)
    : age(age) {

    this->name = new char[strlen(name) + 1];
    strcpy(this->name, name);

    this->phoneNumber = new char[strlen(phoneNumber) + 1];
    strcpy(this->phoneNumber, phoneNumber);

    this->IDcardnumber = new char[strlen(IDcardnumber) + 1];
    strcpy(this->IDcardnumber, IDcardnumber);
    
}

void Customer::saveCustomerInfo() const {
    ofstream file("customers.txt", ios::app);

    if (file.is_open()) {
        // Check if the file is empty
        file.seekp(0, ios::end);
        bool isEmpty = file.tellp() == 0;
        file.seekp(0, ios::beg);  // Reset file pointer to the beginning

        // Write the header if the file is empty
        if (isEmpty) {
            file << " _______________________________________________________________________________" << endl;
            file << "|                   |                   |                   |                   |" << endl;
            file << left << setw(20) << "| Name" << setw(20) << "| Age" << setw(20) << "| Phone" << setw(20) << "| ID Card" << "|" << endl;
            file << "|-------------------------------------------------------------------------------|" << endl;
        }
        // Save customer information to file

            file << left << setw(20) << "| " + string(name)
                 << setw(20) << "| " + to_string(age) 
                 << setw(20) << "| " + string(phoneNumber) 
                 << setw(20) << "| " + string(IDcardnumber) << "|"<< endl;

        file.close();
        cout << "Customer information saved to file." << endl;
    } else {
        cerr << "Unable to open the file for saving customer information." << endl;
    }
}
