***Please check Final Thoughts at the end.***

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

## Final Thoughts (Dev)
1. The entire implementation was done in TDD and designed in DDD.
2. The `HttpClientService` is a wrapper around the HttpClient, as it is hard to test.
3. At this point, there is no *Acquiring Bank* URI available, but I would expect to have it in a config file at a later stage. We can then inject as `Options` and use it.
4. A bank simulator was mentioned but was not provided. I assumed it would accept a `Payment` object and return a `bool`; However, It is not necessary at this stage since the service is mocked, but would become more relevant once we implement the acceptance tests. At that point, integration tests would also be required.
5. I did not make assumptions regarding how the *Acquiring Bank* server would operate, but the `HttpClientService` would naturally have to adapt to it's requirements.
6. There is no data persistence at this point. I would see it in the `Gateway.Data` project, abstracting away the data responsibilities from the Domain, similarly to what `HttpClientService` does. It should be well designed to accommodate possible changes in data access as well (db, file, or even db apis).
7. To wrap up, I understand more deliverables were expected. However, I believe that what is delivered now is enough to showcase how I would approach the problem from a code standpoint and when combined with the white-boarding session, the solution design becomes clear without spending many hours to make the complete solution.
