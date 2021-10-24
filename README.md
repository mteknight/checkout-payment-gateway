# checkout-payment-gateway

## Requirements
The product requirements for this initial phase are the following:
1. A merchant should be able to process a payment through the payment gateway and receive either
   a successful or unsuccessful response.
2. A merchant should be able to retrieve the details of a previously made payment. The next section
   will discuss each of these in more detail.

### Process a payment
   The payment gateway will need to provide merchants with a way to process a payment. To do this, the
   merchant should be able to submit a request to the payment gateway. A payment request should include
   appropriate fields such as the card number, expiry month/date, amount, currency, and cvv.

### Retrieving a payment’s details
The second requirement for the payment gateway is to allow a merchant to retrieve details of a
previously made payment using its identifier. Doing this will help the merchant with their reconciliation
and reporting needs. The response should include a masked card number and card details along with a
status code which indicates the result of the payment.

### Deliverables
1. Build an API that allows a merchant:
   1. To process a payment through your payment gateway.
   2. To retrieve details of a previously made payment.
2. Build a bank simulator to test your payment gateway API.

### Considerations
We’re conscious that home tests can take a long time to finish. We aim for candidates to spend 3 hours
on this test although it's up to you if you want to spend more time. When you submit your solution we’ll
review it and may ask you questions on it in subsequent chats.
Documentation is a key deliverable, spend time here as it lets us understand your thinking. Just some
areas to consider:
- How to run your solution.
- Any assumptions you made.
- Areas for improvement.
- What cloud technologies you’d use and why.
