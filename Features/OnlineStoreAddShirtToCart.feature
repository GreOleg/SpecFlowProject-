Feature: OnlineStoreSearchValue

Scenario: Adding the T-shirt to cart
	Given Start the browser with Online Store
	When In the Search field, enter the value is shirts
	Then Wait for the element under Search with the text is T-shirts > Faded Short Sleeve T- to appear
	When Click on the element under Search with the text is T-shirts > Faded Short Sleeve T-
	And Wait for the product page to appear
	Then Assert that the product name is Faded Short Sleeve T-shirts
	When Click on the Add to cart button
	And Wait for the element with the text is Product successfully added to your shopping cart to appear on page
	Then Assert for the element with the text is Product successfully added to your shopping cart