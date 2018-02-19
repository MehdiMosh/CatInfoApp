How to Run:
	Restore the nuget packages and run the console app.

Considerations:
	The following would be different in a real application but where implemented this way for the sake of simplicity and convenience. 
		Avoided creating multiple projects for simplicity, instead used folders to demonstrate the seperarion.
		Bootstrapper class has two concerns which means it should be split in two.
		The display code in the console, is not unit tested.
		Application logging has not been implemented.
		In Unit test project, Mocks could be injected into the IoC context that is used to spin up required classes. Instead I chose to instantiate the class manually for simplicity.
		Unit test only done for the single Manager class, test cases do not cover all possible scenarios