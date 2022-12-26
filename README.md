# *WIP* - SMSender

Send dynamic marketing text messages in bulk with `Handlebar` arguments. The goal is to implement an UI for users to be able to send fully customized text messages to a list of receivers, with an arbitrary number of arguments that the user can provide and name freely.

Example:

Let's say we create a template text message with a few `Handlebar` arguments:
```
Hello, {{Name}}!
Did you know that you can buy {{ThisWonderfulProduct}} for a limited time for only ${{RidicolousAmountOfMoney}}?
Best regards,
AnyCompany
```

Input arguments:
```
[
  {
    "Name": "Anton",
    "ThisWonderfulProduct": "An umbrella",
    "RidicolousAmountOfMoney": 500,
    "Receiver": "AValidPhoneNumber"
  },
  {
    "Name": "Antonio",
    "ThisWonderfulProduct": "A ferry",
    "RidicolousAmountOfMoney": 2,
    "Receiver": "AnotherValidPhoneNumber"
  }
]
```

The above should result in this app sending two customized messages to `AValidPhoneNumber` and `AnotherValidPhoneNumber`:
```
Hello, Anton!
Did you know that you can buy An umbrella for a limited time for only $500?
Best regards,
AnyCompany
```

```
Hello, Antonio!
Did you know that you can buy A ferry for a limited time for only $2?
Best regards,
AnyCompany
```
