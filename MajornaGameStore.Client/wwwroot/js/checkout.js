function checkout(pubKey, sessionId) {
    const stripe = Stripe(pubKey);
    stripe.redirectToCheckout({ sessionId });
}
//redirection to stripe checkout page