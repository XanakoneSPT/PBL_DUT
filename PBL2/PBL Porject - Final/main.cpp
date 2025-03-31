#include <iostream>
#include <sstream>
#include <cstring>
#include <limits>
#include "AppointmentManager.h"

using namespace std;

int main() {
    cout << endl;
    cout << " _____________________________________________________________________________ \n";
    cout << "|                                                                             |\n";
    cout << "|          De tai : Xay dung ung dung quan ly dat lich cat toc.               |\n";
    cout << "|-----------------------------------------------------------------------------|\n";
    cout << "|     Sinh vien thuc hien:                                                    |\n";
    cout << "|                                                                             |\n";
    cout << "|     Siphanthong Xanakone                                  22T_DT5           |\n";
    cout << "|     Souvannaphoum Athit                                   22T_DT5           |\n";  
    cout << "|_____________________________________________________________________________|\n";
    cout << endl;

    system("pause");

    AppointmentManager manager;
    manager.loadServices();
    manager.loadAppointments();
    manager.displayAppointments();

    while (true) {
        cout << " ______________________________________________________ \n";
        cout << "|                                                      |\n";
        cout << "|                         MENU                         |\n";
        cout << "|------------------------------------------------------|\n";
        cout << "|   1. Book Appointment                                |\n";
        cout << "|   2. Display Appointments                            |\n";
        cout << "|   3. Cancel Appointment                              |\n";
        cout << "|   4. Generate and Export Bill                        |\n";
        cout << "|   5. Export Appointments                             |\n";
        cout << "|   6. Exit                                            |\n";
        cout << "|______________________________________________________|\n";
        cout << endl;
        cout << "** We recommend to check the schedule on the option 2 first for avoid overlap. **" << endl;

        cout << endl;
        cout << "Enter your choice: ";

        int choice;
        string choiceStr;
        getline(cin, choiceStr); // Read the choice as a string

        // Use stringstream to convert the string to an integer
        stringstream ss(choiceStr);
        if (ss >> choice) {
            cout << endl;

            switch (choice) {
                case 1: {
                    char customerName[256];
                    int age;
                    char appointmentTime[6];
                    char date[11];
                    char phoneNumber[15];
                    char IDcardnumber[5];
                    
                    while (true) {
                        cout << "(enter 0 to go back to the main menu)" << endl;
                        cout << endl;

                        // Get customer ID card, name, age, appointment time, date, and phoneNumber
                        cout << "Enter last 4 digits numbers of ID card: ";
                        cin.getline(IDcardnumber, sizeof(IDcardnumber));

                        if (strcmp(IDcardnumber, "0") == 0) {
                            cout << "Going back to the main menu." << endl;
                            break;
                        } else if (cin.fail() || strlen(IDcardnumber) != 4) {
                            cout << "Invalid input. Please enter exactly 4 digits." << endl;
                            cout << endl;

                            // Clear the error flag and flush the input buffer
                            cin.clear();
                            cin.ignore(numeric_limits<streamsize>::max(), '\n');
                        } else {
                           cout << "Enter customer name: ";
                            cin.getline(customerName, sizeof(customerName));
                            // Check if the user wants to go back
                            if (strcmp(customerName, "0") == 0) {
                                cout << "Going back to the main menu." << endl;
                                break; // Exit the switch statement to go back to the main menu
                            }

                            cout << "Enter customer age: ";
                            string ageStr;
                            getline(cin, ageStr);
                            stringstream ssAge(ageStr);
                            if(ssAge >> age){
                                if (age == 0) {
                                    cout << "Going back to the main menu." << endl;
                                    break;
                                }
                            }else {
                                cout << "Invalid input. Please enter a valid integer." << endl;
                            }

                            cout << "Enter appointment time (HH:MM): ";
                            cin.getline(appointmentTime, sizeof(appointmentTime));
                            if (strcmp(appointmentTime, "0") == 0) {
                                cout << "Going back to the main menu." << endl;
                                break;
                            }

                            cout << "Enter appointment date (DD/MM/YYYY): ";
                            cin.getline(date, sizeof(date));
                            if (strcmp(date, "0") == 0) {
                                cout << "Going back to the main menu." << endl;
                                break;
                            }

                            cout << "Enter customer phone number: ";
                            cin.getline(phoneNumber, sizeof(phoneNumber));
                            if (strcmp(phoneNumber, "0") == 0) {
                                cout << "Going back to the main menu." << endl;
                                break;
                            }
                            // Continue with the appointment booking
                            manager.bookAppointment(customerName, age, appointmentTime, date, phoneNumber, IDcardnumber);
                            break;
                        }
                    }
                }
                break;
                case 2:
                    manager.displayAppointments();
                    break;
                case 3: {
                    char IDcardnumber[5];

                    while (true) {
                        cout << "(enter 0 to go back to the main menu)" << endl;
                        cout << "Enter the last 4 digits of the ID card to cancel the appointment: ";
                        cin.getline(IDcardnumber, sizeof(IDcardnumber));

                        if (strcmp(IDcardnumber, "0") == 0) {
                            cout << "Going back to the main menu." << endl;
                            break;
                        } else if (cin.fail() || strlen(IDcardnumber) != 4) {
                            cout << "Invalid input. Please enter exactly 4 digits." << endl;
                            cout << endl;

                            // Clear the error flag and flush the input buffer
                            cin.clear();
                            cin.ignore(numeric_limits<streamsize>::max(), '\n');
                        } else {
                            manager.cancelAppointment(IDcardnumber);
                            break;
                        }
                    }
                }
                break;
                case 4: {
                    char IDcardnumber[5];

                    while (true) {
                        cout << "(enter 0 to go back to the main menu)" << endl;
                        cout << "Enter the last 4 digits of the ID card to cancel the appointment: ";
                        cin.getline(IDcardnumber, sizeof(IDcardnumber));

                        if (strcmp(IDcardnumber, "0") == 0) {
                            cout << "Going back to the main menu." << endl;
                            break;
                        } else if (cin.fail() || strlen(IDcardnumber) != 4) {
                            cout << "Invalid input. Please enter exactly 4 digits." << endl;
                            cout << endl;

                            // Clear the error flag and flush the input buffer
                            cin.clear();
                            cin.ignore(numeric_limits<streamsize>::max(), '\n');
                        } else {
                            manager.generateBillAndMarkAsCompleted(IDcardnumber);
                            break;
                        }
                    }
                }
                break;
                case 5: {
                    char exportDate[11];
                    while (true) {
                        cout << "(enter 0 to go back to the main menu)" << endl;
                        cout << "Enter the date to export appointments (DD/MM/YYYY) or 'all' for all appointments: ";
                        cin.getline(exportDate, sizeof(exportDate));

                        if (strcmp(exportDate, "0") == 0) {
                            cout << "Going back to the main menu." << endl;
                            break;
                        } else if (strcmp(exportDate, "all") == 0) {
                            manager.exportAppointmentsByDate(exportDate);
                            break;
                        } else if (cin.fail() || strlen(exportDate) != 10) {
                            cout << "Invalid input. Please check if you enter the correct format." << endl;
                            cout << endl;

                            // Clear the error flag and flush the input buffer
                            cin.clear();
                            cin.ignore(numeric_limits<streamsize>::max(), '\n');
                        } else {
                            manager.exportAppointmentsByDate(exportDate);
                            break;
                        }
                    }
                }
                break;
                case 6:
                    manager.saveAppointments();
                    cout << "Exiting the application. Goodbye!" << endl;
                    return 0;
                default:
                    cout << "Invalid choice. Please try again." << endl;
                    break;
            }
        }
        else {
            cout << "Invalid input. Please enter a valid integer choice." << endl;
        }
    }

    return 0;
}
