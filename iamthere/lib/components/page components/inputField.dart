import 'package:flutter/material.dart';

class InputField extends StatefulWidget {
  final _controller;
  final _text;
  final Function(String) onChangedFunction;
  const InputField(this._controller, this._text,
      {Key key, this.onChangedFunction})
      : super(key: key);
  @override
  State<StatefulWidget> createState() {
    // TODO: implement createState
    return _InputField(_controller, _text,
        onChangedFunction: onChangedFunction);
  }
}

class _InputField extends State<InputField> {
  final _controller;
  final _text;
  final Function(String) onChangedFunction;
  _InputField(this._controller, this._text, {this.onChangedFunction});

  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: TextField(
        style: TextStyle(color: Colors.white),
        cursorColor: Colors.white,
        controller: _controller,
        onChanged: onChangedFunction ?? null,
        decoration: InputDecoration(
            labelText: _text,
            labelStyle: new TextStyle(color: Colors.white),
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
