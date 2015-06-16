using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Crack_Tomb{

    public class Boden{

        public int ID;

        public VertexPositionColor[] ver = new VertexPositionColor[6];
        public VertexPositionColor[] verIntern  = new VertexPositionColor[4];

        public int Ebenen; 
        //Anzahl der Ebenen



        public Boden(float PosX, float PosY, float PosZ) {

            verIntern[0] = new VertexPositionColor(new Vector3(PosX, PosY, PosZ), Color.White);
            verIntern[1] = new VertexPositionColor(new Vector3(PosX + 1.0f, PosY, PosZ), Color.White);
            verIntern[2] = new VertexPositionColor(new Vector3(PosX, PosY, PosZ + 0.2f), Color.White);
            verIntern[3] = new VertexPositionColor(new Vector3(PosX + 1.0f, PosY, PosZ + 1.0f), Color.White);
            ver[0] = verIntern[0]; ver[1] = verIntern[1]; ver[2] = verIntern[3];
            ver[3] = verIntern[0]; ver[4] = verIntern[3]; ver[5] = verIntern[2];
        
        }


    }
}
