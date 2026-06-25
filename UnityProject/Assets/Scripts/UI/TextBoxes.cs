namespace FlorianMan.UI
{
    public enum TextBoxes
    {
        //General
        PocketWatchMorning1,                        // First Time opening Clock
        PocketWatchMorning2,                        // Open Clock with Cogwheel in Inventory
        RecordPlayerArrivalSameRoom,                // On Evening Arrival in Same Room as Record Player
        RecordPlayerArrivalOtherRoom,               // On Evening Arrival in Other Room than Record Player
        TelephoneRinging,                           // In the Afternoon, when the Telephone starts ringing
        TelephoneResponse,                          // In the Afternoon, after listening to the incoming call
        EnterLivingRoomAfternoon,                   // First Time entering Living Room Afternoon
        EnterLivingRoomNoonKnowingBananaPeelChair,  // First Time entering Living Room Noon, with Clue BananaPeelBehindChair
        
        //Living Room
        BodyOutline,
        CorpseWithShurikens,
        ShurikensInFloor,
        ShurikensHangingOnCeiling,
        BananaPeelNextToCorpse,
        BananaPeelBehindChair,
        CeilingFanSwitchOnUltra,
        CeilingFanSwitchOnNormal,
        CeilingFanBroken,
        CeilingFanWorking,
        OldTelephoneMorning,                        // Interaction when Emergency Note was not found
        OldTelephoneMurderDay,                      // Every Interaction on the Day of Murder
        NoteUnderneathShelf,
        ToyBeforeCall,
        ToyOnShelfMorning,
        ToyOnShelfMurderDay,
        CryssAngleVinyl,
        
        //Kitchen
        CakeRecipe,
        FridgeFreeze,                               // Every Open Fridge interaction, before switching mode once
        FridgeRegulator,                            // Every Time putting the Fridge in Warm Mode
        FridgeFreezeButter,                         // Open Fridge on Noon
        RavioliCanMorning,
        RavioliCanMurderDay,
        Bananas4,
        Bananas5,
        Microwave,                                  // Every Interaction with Microwave
        
        //Bedroom
        Bed,
        RecordPlayerMorning,                        // Every Interaction with Record Player at Morning
        RecordPlayerEvening,                        // First Interaction with Record Player at Evening
        MusicVinylOut,                              // First Time Releasing the Music Vinyl from the Record Player
        CryssAngleVinylIn,                          // First Time placing the Cryss Angle Vinyl
        CryssAngleVinylForward,                     // First Time playing the Cryss Angle Vinyl Forward
        CryssAngleVinylBackwards,                   // First Time playing the Cryss Angle Vinyl Backwards
        InvitationLetter,
        NoteInBedroom,
        
        //Basement
        CircularSawDryBlood,
        CircularSawFreshBlood,
        PieceOfButterUnreachable,
        PieceOfButterReachable,
        Finger,
        
        Empty,
    }
}