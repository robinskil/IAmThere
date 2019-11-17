class UserRegisterModel {
  final String _email;
  final String _password;
  final String _firstName;
  final String _lastName;

  UserRegisterModel(
      this._email, this._password, this._firstName, this._lastName);

  Map<String, dynamic> toJson() => {
        'email': _email,
        'password': _password,
        'firstName': _firstName,
        'lastName': _lastName,
      };
}
