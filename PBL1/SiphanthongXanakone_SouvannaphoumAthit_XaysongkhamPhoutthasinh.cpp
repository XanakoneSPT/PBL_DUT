#include <iostream>
#include <string>
#include <cmath>
#include <limits>
#include <iomanip>

using namespace std;

// function prototypes
void menu();
string decimalToBinary(double decimal);
string decimalToOctal(double decimal);
string decimalToHexadecimal(double decimal);
double binaryToDecimal(string binary);
double octalToDecimal(string octal);
double hexadecimalToDecimal(string hexadecimal);
string binaryToHexadecimal(string binary);
string binaryToOctal(string binary);
string octalToBinary(string octal);
string hexadecimalToBinary(string hexadecimal);

int main(){

    cout << endl;
    cout << " _____________________________________________________________________________ \n";
    cout << "|                                                                             |\n";
    cout << "|          De tai : Xay dung ung dung chuyen doi giua cac he dem.             |\n";
    cout << "|-----------------------------------------------------------------------------|\n";
    cout << "|     Sinh vien thuc hien:                                                    |\n";
    cout << "|                                                                             |\n";
    cout << "|     Siphanthong Xanakone                                  22T_DT5           |\n";
    cout << "|     Souvannaphoum Athit                                   22T_DT5           |\n";  
    cout << "|     Xaysongkham Phoutthasinh                              22T_DT5           |\n";
    cout << "|_____________________________________________________________________________|\n";
    cout << endl;
    
    system("pause");
    // system("cls");

	menu();
	
	return 0;
	
}

void menu(){
    int choice;
    double decimal;
    string binary, octal, hexadecimal;

    //system("Color 3");

    do{
        cout << " _________________________________________________________ \n";
        cout << "|                                                         |\n";
        cout << "|                          MENU                           |\n";
        cout << "|---------------------------------------------------------|\n";
        cout << "|   1. Convert from decimal to binary                     |\n";
        cout << "|   2. Convert from decimal to octal                      |\n";
        cout << "|   3. Convert from decimal to hexadecimal                |\n";
        cout << "|   4. Convert from binary to decimal                     |\n";
        cout << "|   5. Convert from octal to decimal                      |\n";
        cout << "|   6. Convert from hexadecimal to decimal                |\n";
        cout << "|   7. Convert from binary to hexadecimal                 |\n";
        cout << "|   8. Convert from binary to octal                       |\n";
        cout << "|   9. Convert from octal to binary                       |\n";
        cout << "|   10. Convert from hexadecimal to binary                |\n";
        cout << "|   11. Exit                                              |\n";
        cout << "|_________________________________________________________|\n";
        cout << endl;
        cout << "Please choose an option: ";

        if (cin >> choice) {
	        switch (choice) {
	            case 1:
                    cout << endl;
	                cout << "Enter decimal number: " /* << "\033[33m" */;
	                cin >> decimal;
	                cout << "Binary equivalent: " << decimalToBinary(decimal) << endl;
	                break;
	            case 2:
                    cout << endl;
	                cout << "Enter decimal number: ";
	                cin >> decimal;
	                cout << "Octal equivalent: " << decimalToOctal(decimal) << endl;
	                break;
                case 3:
                    cout << endl;
	                cout << "Enter decimal number: ";
	                cin >> decimal;
	                cout << "Hexadecimal equivalent: " << decimalToHexadecimal(decimal) << endl;
	                break;
                case 4:
                    cout << endl;
	                cout << "Enter binary number: ";
	                cin >> binary;
	                cout << "Decimal equivalent: " << binaryToDecimal(binary) << endl;
	                break;
                case 5:
                    cout << endl;
                    cout << "Enter octal number: ";
                    cin >> octal;
                        if (octal.find('.') == std::string::npos) {
                            // If there is no decimal point, convert octal to integer
                            int decimalEquivalent = stoi(octal, 0, 8);
                            cout << "Decimal equivalent: " << decimalEquivalent << endl;
                        } else {
                            cout << "Decimal equivalent: " << octalToDecimal(octal) << endl;
                        }
                    break;
                case 6:
                    cout << endl;
                    cout << "Enter hexadecimal number: ";
                    cin >> hexadecimal;
                    try {
                        if (hexadecimal.find('.') == std::string::npos) {
                            // If there is no decimal point, convert hexadecimal to integer
                            int decimal_int = stoi(hexadecimal, nullptr, 16);
                            cout << "Decimal equivalent: " << decimal_int << endl;
                        } else {
                            cout << "Decimal equivalent: " << hexadecimalToDecimal(hexadecimal) << endl;
                        }
                    } catch (const invalid_argument& e) {
                        cout << "Error: " << e.what() << endl;
                    }
                    break;
                case 7:
                    cout << endl;
	                cout << "Enter binary number: ";
	                cin >> binary;
	                cout << "Hexadecimal equivalent: " << binaryToHexadecimal(binary) << endl;
	                break;
                case 8:
                    cout << "Enter binary number: ";
                    cin >> binary;
                    cout << "Octal equivalent: " << binaryToOctal(binary) << endl;
                    break;
                case 9:
	                cout << "Enter octal number: ";
	                cin >> octal;
	                cout << "Binary equivalent: " << octalToBinary(octal) << endl;
	                break;
	            case 10:
	                cout << "Enter hexadecimal number: ";
	                cin >> hexadecimal;
	                cout << "Binary equivalent: " << hexadecimalToBinary(hexadecimal) << endl;
	                break;
	            case 11:
                    cout << endl;
	                cout << "\033[31m" << "Exiting program...." << "\033[0m" << endl;
	                break;
	        default:
	            cout << "Invalid choice. Please enter a number from 1 to 11." << endl;
            }
    }else{
                cout << "Invalid input. Please enter a number." << endl;
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
                system("pause");
                //system("cls");
                return menu();
}

if (choice == 11) {
    break;
}

cout << endl;
// prompt the user to continue
cout << "Do you want to continue? (y/n): ";
char answer;
cin >> answer;

// check user's answer
if (answer == 'y' || answer == 'Y') {
    // user wants to continue, so loop back to the beginning
    //system("cls");
    continue;
} else if (answer == 'n' || answer == 'N') {
    // user wants to exit the program, so break out of the loop
    cout << endl;
    cout << "\033[31m" <<"Exiting program...." << "\033[0m";
    break;
} else {
    // user entered an invalid response, so ask again
    cout << "Invalid response. Please enter 'y' or 'n'." << endl;
    
    system("pause");
    //system("cls");
}
}while (choice != 11);}

// 1 function to convert decimal to binary
string decimalToBinary(double decimal) {
    string binary = "";
    bool isNegative = false;

    if (decimal < 0) {
        isNegative = true;
        decimal = abs(decimal);
    }

    // Split decimal into integer and fractional parts
    string decimalStr = to_string(decimal);
    size_t decimalPointPos = decimalStr.find('.');
    int integerPart = stoi(decimalStr.substr(0, decimalPointPos));
    double fractionalPart = (decimalPointPos == string::npos) ? 0 : stod(decimalStr.substr(decimalPointPos));

    // Convert integer part to binary
    while (integerPart > 0) {
        int remainder = integerPart % 2;
        binary = to_string(remainder) + binary;
        integerPart /= 2;
    }

    // Add decimal point to binary string if fractional part is not zero
    if (fractionalPart > 0) {
        binary += '.';

        // Convert fractional part to binary
        int maxFractionalBits = 32; // maximum number of bits for fractional part
        while (fractionalPart > 0 && binary.length() < maxFractionalBits) {
            fractionalPart *= 2;
            int digit = int(fractionalPart);
            binary += to_string(digit);
            fractionalPart -= digit;
        }
    }

    if (isNegative) {
        binary = "-" + binary;
    }

    return binary;
}

// 2 function to convert decimal to octal
string decimalToOctal(double decimal) {
    string octal = "";
    bool isNegative = false;

    if (decimal < 0) {
        isNegative = true;
        decimal = abs(decimal);
    }

    // Split decimal into integer and fractional parts
    string decimalStr = to_string(decimal);
    size_t decimalPointPos = decimalStr.find('.');
    int integerPart = stoi(decimalStr.substr(0, decimalPointPos));
    double fractionalPart = (decimalPointPos == string::npos) ? 0 : stod(decimalStr.substr(decimalPointPos));

    // Convert integer part to octal
    if (integerPart == 0) {
        octal = "0";
    } else {
        while (integerPart > 0) {
            int remainder = integerPart % 8;
            octal = to_string(remainder) + octal;
            integerPart /= 8;
        }
    }

    // Add fractional part to octal string if not zero
    if (fractionalPart > 0) {
        octal += '.';
        int maxFractionalDigits = 12; // maximum number of digits for fractional part

        for (int i = 0; i < maxFractionalDigits; i++) {
            fractionalPart *= 8;

            int digit = int(fractionalPart);

            octal += to_string(digit);
            fractionalPart -= digit;
        }

        // Remove trailing zeros
        while (octal.back() == '0') {
            octal.pop_back();
        }

        // Remove decimal point if no fractional digits
        if (octal.back() == '.') {
            octal.pop_back();
        }
    }

    if (isNegative) {
        octal = "-" + octal;
    }
    return octal;
}

// 3 function to convert decimal to hexadecimal
string decimalToHexadecimal(double decimal) {
    string hexadecimal = "";
    bool isNegative = false;

    if (decimal < 0) {
        isNegative = true;
        decimal = abs(decimal);
    }

    // Split decimal into integer and fractional parts
    string decimalStr = to_string(decimal);
    size_t decimalPointPos = decimalStr.find('.');
    string integerPartStr = decimalStr.substr(0, decimalPointPos);
    string fractionalPartStr = (decimalPointPos == string::npos) ? "" : decimalStr.substr(decimalPointPos + 1);

    // Convert integer part to hexadecimal
    if (integerPartStr == "0") {
        hexadecimal = "0";
    } else {
        long long integerPart = stoll(integerPartStr);
        while (integerPart > 0) {
            int remainder = integerPart % 16;
            if (remainder < 10) {
                hexadecimal = to_string(remainder) + hexadecimal;
            } else {
                char hexChar = 'A' + remainder - 10;
                hexadecimal = hexChar + hexadecimal;
            }
            integerPart /= 16;
        }
    }

    // Add fractional part to hexadecimal string if not zero
    if (!fractionalPartStr.empty()) {
        hexadecimal += '.';
        double fractionalPart = stod("0." + fractionalPartStr);
        int maxFractionalDigits = 6; // maximum number of digits for fractional part
        for (int i = 0; i < maxFractionalDigits && fractionalPart > 0; i++) {
            fractionalPart *= 16;
            int digit = int(fractionalPart);
            if (digit < 10) {
                hexadecimal += to_string(digit);
            } else {
                char hexChar = 'A' + digit - 10;
                hexadecimal += hexChar;
            }
            fractionalPart -= digit;
        }
    }

    if (isNegative) {
        hexadecimal = "-" + hexadecimal;
    }

    return hexadecimal;
}

// 4 function to convert Binary to Decimal
double binaryToDecimal(string binary) {
    bool isNegative = false;

    // Check if binary number is negative
    if (binary[0] == '-') {
        isNegative = true;
        binary = binary.substr(1);
    }

    // Split binary string into integer and fractional parts
    size_t decimalPointPos = binary.find('.');
    string integerPartStr = (decimalPointPos == string::npos) ? binary : binary.substr(0, decimalPointPos);
    string fractionalPartStr = (decimalPointPos == string::npos) ? "" : binary.substr(decimalPointPos + 1);

    // Convert integer part to decimal
    double integerPart = 0;
    for (int i = 0; i < integerPartStr.length(); i++) {
        integerPart += (integerPartStr[i] - '0') * pow(2, integerPartStr.length() - i - 1);
    }

    // Convert fractional part to decimal
    double fractionalPart = 0;
    for (int i = 0; i < fractionalPartStr.length(); i++) {
        fractionalPart += (fractionalPartStr[i] - '0') * pow(2, -(i + 1));
    }

    double decimal = integerPart + fractionalPart;

    if (isNegative) {
        decimal = -decimal;
    }

    return decimal;
}

// 5 Function to convert Octal to Decimal
double octalToDecimal(string octal) {
    bool isNegative = false; // Flag to indicate if the octal number is negative
    double decimal = 0.0; // Variable to store the decimal value
    double base = 1.0; // Base value for converting each digit

    // Check if the number is negative
    if (octal[0] == '-') {
        isNegative = true;
        octal = octal.substr(1); // Remove the negative sign from the octal number
    }

    // Handle integer part
    int decimalPointIndex = -1; // Index of the decimal point in the octal number

    for (int i = 0; i < octal.length(); i++) {
        if (octal[i] == '.') {
            decimalPointIndex = i;
            break;
        }
    }

    if (decimalPointIndex == -1) {
        decimalPointIndex = octal.length(); // If no decimal point is found, consider the entire string as the integer part
    }

    for (int i = decimalPointIndex - 1; i >= 0; i--) {
        decimal += (octal[i] - '0') * base; // Convert each octal digit to decimal and multiply by the base
        base *= 8.0; // Multiply the base by 8 for each digit
    }

    // Handle fractional part
    if (decimalPointIndex != octal.length()) {
        base = 1.0 / 8.0; // Reset the base to handle the fractional part

        for (int i = decimalPointIndex + 1; i < octal.length(); i++) {
            decimal += (octal[i] - '0') * base; // Convert each octal digit to decimal and multiply by the base
            base /= 8.0; // Divide the base by 8 for each digit to handle the fractional part
        }
    }

    // Handle negative numbers
    if (isNegative) {
        decimal = -decimal; // If the octal number was originally negative, make the decimal number negative
    }

    double epsilon = 1.0 / pow(10, numeric_limits<double>::digits10); // Calculate the smallest possible change in double precision

    int maxSignificantDigits = -floor(log10(epsilon) - log10(decimal)); // Calculate the maximum number of significant digits required for precision

    cout.precision(numeric_limits<double>::digits10 - floor(log10(epsilon) - log10(decimal)) + 1); // Set the precision of the decimal value

    return decimal; // Return the decimal value
}

// 6 Function to convert hexadecimal to decimal
double hexadecimalToDecimal(string hexadecimal) {

    double decimal = 0; // Variable to store the decimal value
    double fractional = 0; // Variable to store the fractional part of the decimal value
    bool isNegative = false; // Flag to indicate if the hexadecimal value is negative

    if (hexadecimal[0] == '-') {
        isNegative = true;
        hexadecimal = hexadecimal.substr(1); // Remove the negative sign from the hexadecimal value
    }

    int decimalPointIndex = hexadecimal.find("."); // Find the index of the decimal point in the hexadecimal value

    if (decimalPointIndex == -1) {
        decimalPointIndex = hexadecimal.length();
    }

    // Convert the integer part of the hexadecimal value to decimal
    for (int i = decimalPointIndex - 1; i >= 0; i--) {
        char digit = hexadecimal[i];

        if (isdigit(digit)) {
            decimal += (digit - '0') * pow(16, decimalPointIndex - 1 - i);
        } else {
            digit = toupper(digit);
            decimal += (digit - 'A' + 10) * pow(16, decimalPointIndex - 1 - i);
        }
    }

    // Convert the fractional part of the hexadecimal value to decimal
    if (decimalPointIndex < hexadecimal.length()) {
        for (int i = decimalPointIndex + 1; i < hexadecimal.length(); i++) {
            char digit = hexadecimal[i];
            if (isdigit(digit)) {
                fractional += (digit - '0') * pow(16, decimalPointIndex - i);
            } else {
                digit = toupper(digit);
                fractional += (digit - 'A' + 10) * pow(16, decimalPointIndex - i);
            }
        }
    }

    decimal += fractional; // Add the fractional part to the decimal value

    double epsilon = 1.0 / pow(10, numeric_limits<double>::digits10); // Calculate the smallest possible change in double precision

    int maxFractionalDigits = -floor(log10(epsilon) - log10(decimal)); // Calculate the maximum number of fractional digits required for precision

    if (isNegative) {
        decimal = -decimal;
    }

    // Set the precision of the decimal value
    cout.precision(numeric_limits<double>::digits10 - floor(log10(epsilon) - log10(decimal)) + 1);

    return decimal; // Return the decimal value
}

// 7 function to convert binary to hexadecimal
string binaryToHexadecimal(string binary) {
double decimal = binaryToDecimal(binary);
return decimalToHexadecimal(decimal);
}

// 8 function to convert binary to octal
string binaryToOctal(string binary) {
double decimal = binaryToDecimal(binary);
return decimalToOctal(decimal);
}

// 9 function to convert octal to binary
string octalToBinary(string octal) {
double decimal = octalToDecimal(octal);
return decimalToBinary(decimal);
}

// 10 function to convert hexadecimal to binary
string hexadecimalToBinary(string hexadecimal) {
double decimal = hexadecimalToDecimal(hexadecimal);
return decimalToBinary(decimal);
}
