import 'dart:convert';
import 'dart:io';
import 'package:flutter_spinkit/flutter_spinkit.dart';
import 'package:iamthere/components/login.dart';
import 'package:modal_progress_hud/modal_progress_hud.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:iamthere/components/page%20components/inputField.dart';
import 'package:iamthere/components/page%20components/inputFormField.dart';
import 'package:iamthere/components/page%20components/inputFormFieldObscure.dart';
import 'package:iamthere/helpers/validator.dart';
import 'package:iamthere/models/userRegisterModel.dart';
import 'package:http/http.dart' as http;

class RegisterScreen extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    // TODO: implement createState
    return _RegisterScreen();
  }
}

class _RegisterScreen extends State<RegisterScreen> {
  bool registering = false;
  bool autovalidate = false;
  final _emailController = TextEditingController();
  final _firstNameController = TextEditingController();
  final _lastNameController = TextEditingController();
  final _passwordController = TextEditingController();
  final _passwordReEnterController = TextEditingController();
  final GlobalKey<FormBuilderState> _fbKey = GlobalKey<FormBuilderState>();

  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    return Scaffold(
      backgroundColor: Color(0xFF8185E2),
      body: Center(
        child: SingleChildScrollView(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            children: <Widget>[
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: Text(
                  "Hi there ${_firstNameController.text},",
                  style: TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 35.0,
                      color: Colors.white),
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: Text(
                  'Welcome to "I Am There"',
                  style: TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 20.0,
                      color: Colors.white),
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(20.0),
                child: FormBuilder(
                  key: _fbKey,
                  autovalidate: autovalidate,
                  child: Column(
                    children: <Widget>[
                      InputFormField(
                        _emailController,
                        "Email",
                        validatorFunction:
                            Validator.emailValidator(_emailController.text),
                      ),
                      InputFormField(
                        _firstNameController,
                        "First name",
                        validatorFunction: Validator.firstNameValidator(
                            _firstNameController.text),
                      ),
                      InputFormField(
                        _lastNameController,
                        "Last name",
                        validatorFunction: Validator.lastNameValidator(),
                      ),
                      InputFormFieldObscure(
                        _passwordController,
                        "Password",
                        validatorFunction: Validator.passwordValidator(
                            _passwordController.text),
                      ),
                      InputFormFieldObscure(
                        _passwordReEnterController,
                        "Re-enter password",
                        validatorFunction: Validator.passwordValidatorReEnter(
                            _passwordController),
                      )
                    ],
                  ),
                ),
              ),
              ButtonBar(
                alignment: MainAxisAlignment.center,
                children: <Widget>[
                  ButtonTheme(
                    minWidth: 150,
                    height: 50,
                    child: RaisedButton(
                      shape: RoundedRectangleBorder(
                        borderRadius: new BorderRadius.circular(5.0),
                      ),
                      color: Colors.white,
                      onPressed: () => {
                        setState(() {
                          autovalidate = true;
                        }),
                        if (_fbKey.currentState.validate()) {register(context)}
                      },
                      textColor: Color(0xFF8185E2),
                      child: Text(
                        "Register",
                      ),
                    ),
                  ),
                  ButtonTheme(
                      minWidth: 150,
                      height: 50,
                      child: RaisedButton(
                        shape: RoundedRectangleBorder(
                          borderRadius: new BorderRadius.circular(5.0),
                        ),
                        color: Colors.white,
                        onPressed: () => {Navigator.pop(context)},
                        textColor: Color(0xFF8185E2),
                        child: Text("Cancel"),
                      ))
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }

  void registered(BuildContext context) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return Dialog(
          elevation: 0,
          backgroundColor: Colors.transparent,
          child: Center(
            child: new Row(
              mainAxisSize: MainAxisSize.min,
              children: [
                Padding(
                  padding: const EdgeInsets.all(35.0),
                  child: new Text(
                    "Welcome ${_firstNameController.text}",
                    style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 25.0,
                        color: Colors.white),
                  ),
                ),
              ],
            ),
          ),
        );
      },
    );
  }

  void register(BuildContext context) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return Dialog(
          elevation: 0,
          backgroundColor: Colors.transparent,
          child: Center(
            child: new Row(
              mainAxisSize: MainAxisSize.min,
              children: [
                new SpinKitFadingCube(
                  color: Colors.white,
                ),
                Padding(
                  padding: const EdgeInsets.all(35.0),
                  child: new Text(
                    "Registering...",
                    style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 25.0,
                        color: Colors.white),
                  ),
                ),
              ],
            ),
          ),
        );
      },
    );
    if (_fbKey.currentState.validate()) {
      UserRegisterModel userRegisterModel = UserRegisterModel(
          _emailController.text,
          _passwordController.text,
          _firstNameController.text,
          _lastNameController.text);

      // var url = 'https://10.0.2.2:5001/api/user/register';
      // var response = await http.post(url, body: userRegisterModel.toJson());
      // print('Response status: ${response.statusCode}');
      // print('Response body: ${response.body}');

      HttpClient client = new HttpClient();
      client.badCertificateCallback =
          ((X509Certificate cert, String host, int port) => true);
      String url = 'https://10.0.2.2:5001/api/user/register';
      Map map = userRegisterModel.toJson();
      client.postUrl(Uri.parse(url)).then((request) {
        setState(() {
          registering = true;
        });
        request.headers.set('content-type', 'application/json');
        request.add(utf8.encode(json.encode(map)));
        request.close().then((response) {
          print(response.statusCode);
          response.transform(utf8.decoder).join().then((reply) {
            print(reply);
            setState(() {
              registering = false;
              Navigator.pop(context);
              if (response.statusCode == 200) {
                registered(context);
                Future.delayed(Duration(seconds: 3), () {
                  Navigator.of(context).pushAndRemoveUntil(
                      MaterialPageRoute(builder: (context) => LoginScreen()),
                      (Route<dynamic> route) => false);
                });
              }
            });
          });
        });
      });
    }
  }
}
