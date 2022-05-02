Feature: OnlineStoreSearchValue

Scenario: Adding the T-shirt to cart
	Given I open the App
	When I enter the "shirts" in the Search field
	Then I expect for the element search tooltip "T-shirts > Faded Short Sleeve T-" to appear
	When I click on the element search tooltip "T-shirts > Faded Short Sleeve T-"
	Then I expect for the product page to appear
	And I expect that the product name is "Faded Short Sleeve T-shirts"
	When I click on the Add to cart button
	Then I expect for the element with the text is "Product successfully added to your shopping cart"