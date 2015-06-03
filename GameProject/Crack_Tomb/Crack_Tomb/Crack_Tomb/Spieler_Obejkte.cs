using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crack_Tomb{

    public abstract class Spieler_Obejkte{

        //TODO: Konstruktoren und Drag-Drop Mechanik für die Items

    }

    public class Spiegel : Spieler_Obejkte { 
    
        //TODO:  Textur für grafische Darstellung
    
    }

    public class D_Spiegel : Spieler_Obejkte { 
    
        //TODO: Textur für grafische Darstellung
    
    }

    public class Farbkristall : Spieler_Obejkte { 
    
        //TODO: Textur für grafische Darstellung, mehrere Texturen je nach Farbe
        //TODO: Farbspeicherung
    
    }

    public class Splitprisma : Spieler_Obejkte {

        //TODO: Textur für grafische Darstellung, hier mehrere Texturen benötigt für die verschiedenen Arten

        int Split_Richtung;              //5-bit Intwert (00000).
    
    }

}
