import 'package:flutter/cupertino.dart';

class Validator {
  static const int passwordAmountCharacters = 8;

  static bool validateEmail(String email) {
    return RegExp(
            r"^[a-zA-Z0-9.a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9]+\.[a-zA-Z]+")
        .hasMatch(email);
  }

  static bool isEmpty(String value) {
    return value == null || value.isEmpty;
  }

  static bool minCharacters(String value, int amount) {
    return value.length >= amount;
  }

  static String Function(String) emailValidator(String value) {
    return (value) {
      if (isEmpty(value)) {
        return "An email address is required";
      }
      if (!validateEmail(value)) {
        return "Invalid email address";
      }
      return null;
    };
  }

  static String Function(String) passwordValidator(String value) {
    return (value) {
      if (isEmpty(value)) {
        return "A password is required";
      }
      if (!minCharacters(value, passwordAmountCharacters)) {
        return "Password needs atleast ${passwordAmountCharacters} characters.";
      }
      return null;
    };
  }

  static String Function(String) passwordValidatorReEnter(
      TextEditingController comparer) {
    return (value) {
      print(comparer.text);
      if (isEmpty(value)) {
        //print(value);
        return "A password is required";
      }
      if (!minCharacters(value, passwordAmountCharacters)) {
        return "Password needs atleast ${passwordAmountCharacters} characters.";
      }
      return null;
    };
  }

  static String Function(String) firstNameValidator(String value) {
    return (value) {
      if (isEmpty(value)) {
        return "A first name is required";
      }
      return null;
    };
  }

  static String Function(String) lastNameValidator() {
    return (value) {
      if (isEmpty(value)) {
        return "A last name is required";
      }
      return null;
    };
  }
}
