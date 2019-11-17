import 'package:flutter/material.dart';
import 'package:iamthere/helpers/validator.dart';

class InputFormField extends StatefulWidget {
  final _controller;
  final _text;
  final Function(String) onChangedFunction;
  final String Function(String) validatorFunction;
  const InputFormField(this._controller, this._text,
      {Key key, this.onChangedFunction, this.validatorFunction})
      : super(key: key);
  @override
  State<StatefulWidget> createState() {
    // TODO: implement createState
    return _InputFormField(_controller, _text,
        onChangedFunction: onChangedFunction,
        validatorFunction: this.validatorFunction);
  }
}

class _InputFormField extends State<InputFormField> {
  final _controller;
  final _text;
  final Function(String) onChangedFunction;
  final String Function(String) validatorFunction;
  _InputFormField(this._controller, this._text,
      {this.onChangedFunction, this.validatorFunction});

  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: TextFormField(
        style: TextStyle(color: Colors.white),
        cursorColor: Colors.white,
        controller: _controller,
        onChanged: onChangedFunction ?? null,
        validator: validatorFunction ?? null,
        decoration: InputDecoration(
            labelText: _text,
            labelStyle: new TextStyle(color: Colors.white60),
            focusedBorder: OutlineInputBorder(
                borderSide: new BorderSide(color: Colors.white),
                borderRadius: BorderRadius.all(Radius.circular(
                  10,
                ))),
            enabledBorder: OutlineInputBorder(
                borderSide: new BorderSide(color: Colors.white),
                borderRadius: BorderRadius.all(Radius.circular(
                  10,
                )))),
      ),
    );
  }
}
