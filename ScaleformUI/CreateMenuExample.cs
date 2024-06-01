//Create menu
UIMenu menu = new UIMenu("Ped Interaction Menu", "Pedestrian Interactions", new PointF(20f, 20f), "commonmenu", "interaction_bgd", false, false, 0.1f);

//Create and Add Menu Items
UIMenuItem question1 = new UIMenuItem("Question 1...", "", ScaleformUI.Elements.SColor.Yellow, ScaleformUI.Elements.SColor.White);
menu.AddItem(question1);

UIMenuItem question2 = new UIMenuItem("Question 2...", "This is a description");
menu.AddItem(question2);

//Handle question selected
question1.Activated += async (selectedMenu, selectedItem) =>
{
    //Hide menu while talking to ped
    menu.Visible = false;

    //Show questions
    Screen.ShowSubtitle("Officer: Question 1...", 5000);
    await Delay(5000);
    Screen.ShowSubtitle("Pedestrian: Answer...", 5000);
    await Delay(5000);

    //Change text color
    question1.TextColor = ScaleformUI.Elements.SColor.Gray;
    question1.HighlightColor = ScaleformUI.Elements.SColor.White;

    //Make menu visible
    menu.Visible = true;
};
