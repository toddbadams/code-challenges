# Tokenization 

Store a primary account number (PAN)

**URL** : `/v1/tokens/`

**Method** : `POST`

**Auth required** : YES

**User Role** : None

**Data constraints**

```json
{
    "card": {
      "number": "4242424242424242",
      "exp_month": 7,
      "exp_year": 2021,
      "cvc": "314",
    }
}
```

**Header constraints**

- Authorization: Bearer <token>

## Success Responses

**Condition** : Data provided is valid and User is Authenticated.

**Code** : `200 OK`

**Content example** : Response will reflect back the updated information. A
User with `id` of '1234' sets their name, passing `UAPP` header of 'ios1_2':

```json
{
    "id": "tok_1H0iOw2eZvKYlo2C6MVx5nc5",
  "object": "token",
  "card": {
    "id": "card_1H0iOw2eZvKYlo2CLpaFeqBU",
    "object": "card",
    "address_city": null,
    "address_country": null,
    "address_line1": null,
    "address_line1_check": null,
    "address_line2": null,
    "address_state": null,
    "address_zip": null,
    "address_zip_check": null,
    "brand": "Visa",
    "country": "US",
    "cvc_check": "pass",
    "dynamic_last4": null,
    "exp_month": 8,
    "exp_year": 2021,
    "fingerprint": "Xt5EWLLDS7FJjR1c",
    "funding": "credit",
    "last4": "4242",
    "metadata": {},
    "name": null,
    "tokenization_method": null
  },
  "client_ip": null,
  "created": 1593757774,
  "livemode": false,
  "type": "card",
  "used": false
}
```

## Error Response

**Condition** : If provided data is invalid, e.g. a name field is too long.

**Code** : `400 BAD REQUEST`

**Content example** :

```json
{
    "number": [
        "Please provide a valid credit card number",
    ]
}
```

## Notes

* Each unique card can only be tokenized once.