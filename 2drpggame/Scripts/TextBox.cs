using Godot;
using System;

public partial class TextBox : Control
{
	private float delay = 0.025f; // Time in seconds between each character
	private Label textLabel;
	private string fullText = "";
	int skriver = 0;
	int skriver2 = 0;
	int skriver3 = 0;
	public override void _Ready()
	{
		textLabel = GetNode<Label>("Label");
		textLabel.Text = ""; // Start with an empty label
		Hide();
	}
	
	public void ShowTextBox1()
	{
		fullText = "Da du indsætter de tre nøgler i piedestalen og drejer dem, mærker du, hvordan luften omkring dig ændrer sig. En lav rumlen spreder sig gennem landsbyen, og jorden under dig begynder at vibrere svagt. \n En stråle af lys skyder op fra piedestalen, bryder igennem himlen og afslører en sandhed, du aldrig havde kunnet forestille dig. \n Verden omkring dig begynder at falme, som et maleri, der bliver vasket væk. De trygge huse, de smilende landsbyboere, og de frodige landskaber opløses i intetheden. \n Alt du nogensinde har kendt, er væk. Men samtidig er en ny verden ved at træde frem – en kold, steril virkelighed. \n Hvide vægge omgiver dig nu, og en mekanisk stemme fylder rummet: Eksperiment 47B afsluttet. Subjektets adfærd og beslutninger er blevet nøje registreret.\n Resultaterne vil blive brugt til yderligere forskning i menneskelig nysgerrighed og selvstændighed. Tak for din deltagelse. \n Du står alene tilbage, omringet af teknologi, der er langt mere avanceret, end noget du nogensinde har set. Alt føles fremmed, men samtidig fornemmer du en mærkelig ro. \n Du tog springet. Du udforskede det ukendte og fandt sandheden – uanset hvor uventet og skræmmende den måtte være. \n Et panel glider op fra væggen, og en dør åbner sig. Et nyt eventyr venter derude, i en verden, hvor intet længere er givet på forhånd. \n Du har gennemført spillet – men historien er kun lige begyndt. ";
		Show();
		ShowText();
		GD.Print("BegyndSlut");
	}
	
	public void ShowTextBox2()
	{
		if (skriver == 0)
		{
		Show();
		ShowText();
		fullText = "HHi, stranger! \n What a surprise it is to see a villager out here in the woods. \n Usually, nobody journeys to this forest. \n You need to be careful - The slimes do NOT want to be friends. \n Come to think of it. They might be defending something. \n Oh well, that’s not my concern. \n Perhaps you can investigate what they’re hiding.  Be safe, stranger!";
		textLabel.Text = "";
		}
	}
	public void ShowTextBox3()
	{
		if (skriver2 == 0)
		{
			Show();
			ShowText();
			fullText = "HHello, traveller! \n Oh my, it’s been ages since I’ve last encountered humans in these surroundings. \n I think I know why you’ve ventured all this way… \n You wish to know the true nature of the totems, yes? \n Ah, you do strike me as the curious type, indeed. I’ll tell you what; \n Somewhere around these frosty landscapes lives a group of skeletons. \n I believe they guard an ancient key. \n Defeat them, and the key can be yours. \n I wish you good luck, traveller! ";
			textLabel.Text = "";
		}
	}
	public void ShowTextBox4()
	{
		if (skriver3 == 0)
		{
			Show();
			ShowText();
			fullText = "WWoah, easy there, voyager! I suspected you were a mirage. \n Your kind are very seldom seen in these scorching dunes. \n You must be searching for something, knowledge and meaning? \n Listen, there may be an old remnant amongst all these grains of sand. \n It can aid you… but be warned! It is likely protected. \n Overcome those that stand in your way, and take it!";
			textLabel.Text = "";
		}
	}
	public void HideTextBox()
	{
		Hide();
		skriver = 1;
	}
	
	public void HideTextBox2()
	{
		Hide();
		skriver2 = 1;
	}
	
	public void HideTextBox3()
	{
		Hide();
		skriver3 = 1;
	}
	private async void ShowText()
	{
		foreach (char c in fullText)
		{
			textLabel.Text += c; // Add one character at a time
			await ToSignal(GetTree().CreateTimer(delay), "timeout"); // Wait for the delay
		}
	}
}
