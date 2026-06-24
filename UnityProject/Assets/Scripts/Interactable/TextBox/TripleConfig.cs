using FlorianMan.UI;
using FlorianMan.Watch;
using UnityEngine;

public class TripelConfig : MonoBehaviour
{
    [SerializeField] private TextBoxActivated throwingStars;
    [SerializeField] private TextBoxActivated ceilingFan;
    [SerializeField] private TextBoxActivated chair;
    [SerializeField] private TextBoxActivated bananaPeel;
    [SerializeField] private TextBoxActivated corpse;
    [SerializeField] private TextBoxActivated toy;
    [SerializeField] private TextBoxActivated telephone;
    [SerializeField] private TextBoxActivated bananas;
    [SerializeField] private TextBoxActivated emergencyCallNote;
    [SerializeField] private TextBoxActivated ceilingFanRemoteControl;
    [SerializeField] private TextBoxActivated butter;
    [SerializeField] private TextBoxActivated finger;
    [SerializeField] private TextBoxActivated buzzSaw;
    [SerializeField] private TextBoxActivated shelf;
    [SerializeField] private TextBoxActivated fridge;
    [SerializeField] private TextBoxActivated ravioliCan;
    [SerializeField] private TextBoxActivated microwave;
    [SerializeField] private TextBoxActivated recordPlayer;
    [SerializeField] private TextBoxActivated bed;
    [SerializeField] private TextBoxActivated invitationLetter;

    private void Awake()
    {
        TripleHandler.instance.Add(Times.Evening, TextBoxes.ShurikensInFloor, throwingStars);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.ShurikensHangingOnCeiling, throwingStars);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.ShurikensHangingOnCeiling, throwingStars);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.CeilingFanBroken, ceilingFan);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.CeilingFanBroken, ceilingFan);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.CeilingFanWorking, ceilingFan);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.CeilingFanWorking, ceilingFan);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.BananaPeelNextToCorpse, bananaPeel);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.BananaPeelNextToCorpse, bananaPeel);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.BananaPeelBehindChair, bananaPeel);
        //TripleHandler.instance.Add(Times.Noon, , bananaPeel);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.ToyOnShelfMorning, toy);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.ToyOnShelfMurderDay, toy);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.ToyOnShelfMurderDay, toy);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.ToyOnShelfMurderDay, toy);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.OldTelephoneMorning, telephone);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.OldTelephoneMurderDay, telephone);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.OldTelephoneMurderDay, telephone);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.OldTelephoneMurderDay, telephone);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.Bananas4, bananas);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.Bananas4, bananas);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.Bananas4, bananas);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.Bananas5, bananas);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.BodyOutline, corpse);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.CorpseWithShurikens, corpse);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.CeilingFanSwitchOnUltra, ceilingFanRemoteControl);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.CeilingFanSwitchOnUltra, ceilingFanRemoteControl);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.CeilingFanSwitchOnNormal, ceilingFanRemoteControl);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.CeilingFanSwitchOnNormal, ceilingFanRemoteControl);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.NoteUnderneathShelf, emergencyCallNote);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.NoteInBedroom, emergencyCallNote);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.NoteInBedroom, emergencyCallNote);

        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.PieceOfButterReachable, butter);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.PieceOfButterUnreachable, butter);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.Finger, finger);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.Finger, finger);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.Finger, finger);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.Finger, finger);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.CircularSawDryBlood, buzzSaw);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.CircularSawDryBlood, buzzSaw);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.CryssAngleVinyl, shelf);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.CakeRecipe, fridge);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.CakeRecipe, fridge);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.CakeRecipe, fridge);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.CakeRecipe, fridge);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.RavioliCanMorning, ravioliCan);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.RavioliCanMorning, ravioliCan);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.RavioliCanMurderDay, ravioliCan);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.RavioliCanMurderDay, ravioliCan);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.Microwave, microwave);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.Microwave, microwave);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.Microwave, microwave);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.Microwave, microwave);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.RecordPlayerMorning, recordPlayer);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.RecordPlayerEvening, recordPlayer);
        //TripleHandler.instance.Add(Times.Afternoon, , recordPlayer);
        //TripleHandler.instance.Add(Times.Noon, , recordPlayer);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.BananaPeelNextToCorpse, bed);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.Bed, bed);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.Bed, bed);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.Bed, bed);

        TripleHandler.instance.Add(Times.Morning, TextBoxes.InvitationLetter, invitationLetter);
        TripleHandler.instance.Add(Times.Evening, TextBoxes.InvitationLetter, invitationLetter);
        TripleHandler.instance.Add(Times.Afternoon, TextBoxes.InvitationLetter, invitationLetter);
        TripleHandler.instance.Add(Times.Noon, TextBoxes.InvitationLetter, invitationLetter);
    }
}