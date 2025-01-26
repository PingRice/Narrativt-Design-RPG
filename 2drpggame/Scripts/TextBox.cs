using Godot;
using System;

public partial class TextBox : Control
{
	private string fullText = "Da du indsætter de tre nøgler i piedestalen og drejer dem, mærker du, hvordan luften omkring dig ændrer sig. \n En lav rumlen spreder sig gennem landsbyen, og jorden under dig begynder at vibrere svagt. \n En stråle af lys skyder op fra piedestalen, bryder igennem himlen og afslører en sandhed, du aldrig havde kunnet forestille dig. \n Verden omkring dig begynder at falme, som et maleri, der bliver vasket væk. De trygge huse, de smilende landsbyboere, og de frodige landskaber opløses i intetheden. \n Alt du nogensinde har kendt, er væk. Men samtidig er en ny verden ved at træde frem – en kold, steril virkelighed. \n Hvide vægge omgiver dig nu, og en mekanisk stemme fylder rummet: Eksperiment 47B afsluttet. Subjektets adfærd og beslutninger er blevet nøje registreret. \n Resultaterne vil blive brugt til yderligere forskning i menneskelig nysgerrighed og selvstændighed. \n Tak for din deltagelse. \n Du står alene tilbage, omringet af teknologi, der er langt mere avanceret, end noget du nogensinde har set. \n Alt føles fremmed, men samtidig fornemmer du en mærkelig ro. \n Du tog springet. Du udforskede det ukendte og fandt sandheden – uanset hvor uventet og skræmmende den måtte være. \n Et panel glider op fra væggen, og en dør åbner sig. Et nyt eventyr venter derude, i en verden, hvor intet længere er givet på forhånd. \n Du har nu gennemført spillet – men historien er kun lige begyndt.";
	private float delay = 0.05f; // Time in seconds between each character
	private Label textLabel;

	public override void _Ready()
	{
		textLabel = GetNode<Label>("Label");
		textLabel.Text = ""; // Start with an empty label
		Hide();
	}
	
	public void ShowTextBox()
	{
		Show();
		ShowText();
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
