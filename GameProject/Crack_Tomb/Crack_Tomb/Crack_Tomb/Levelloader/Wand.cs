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

   public class Wand{

        float PosX;
        float PosY;
        float PosZ;

        float SizeX = 1.0f;
        float SizeY = 1.0f;
        float SizeZ = 1.0f;

        int ID;


        Model Wand_Model;

        public Wand(float hPosX, float hPosY, float hPosZ){

            PosX = hPosX;
            PosY = hPosY;
            PosZ = hPosZ;

        }

        public void draw() {

            //GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, verIntern, 0, 12);
        
        }
    }

   public class Wand_Loch {                                    //identische Mechanik wie normale Wand, nur mit andererer Textur und Kollisionserkennung für den Strahl
   
        float PosX;
        float PosY;
        float PosZ;

        float SizeX = 1.0f;
        float SizeY = 1.0f;
        float SizeZ = 1.0f;

        int ID;

        public VertexPositionColor[] verIntern = new VertexPositionColor[8];
        public VertexPositionColor[] ver = new VertexPositionColor[36];

        public Wand_Loch(float hPosX, float hPosY, float hPosZ){

            PosX = hPosX;
            PosY = hPosY;
            PosZ = hPosZ;
            verIntern[0] = new VertexPositionColor(new Vector3(PosX, PosY, PosZ), Color.Yellow);
            verIntern[1] = new VertexPositionColor(new Vector3(PosX + SizeX, PosY, PosZ), Color.Yellow);
            verIntern[2] = new VertexPositionColor(new Vector3(PosX, PosY, PosZ + SizeZ), Color.Yellow);
            verIntern[3] = new VertexPositionColor(new Vector3(PosX + SizeX, PosY, PosZ + SizeZ), Color.Yellow);
            verIntern[4] = new VertexPositionColor(new Vector3(PosX, PosY + SizeY, PosZ), Color.Yellow);
            verIntern[5] = new VertexPositionColor(new Vector3(PosX + SizeX, PosY + SizeY, PosZ), Color.Yellow);
            verIntern[6] = new VertexPositionColor(new Vector3(PosX, PosY + SizeY, PosZ + SizeZ), Color.Yellow);
            verIntern[7] = new VertexPositionColor(new Vector3(PosX + SizeX, PosY + SizeY, PosZ + SizeZ), Color.Yellow);
            ver[0] = verIntern[0]; ver[1] = verIntern[1]; ver[2] = verIntern[3];
            ver[3] = verIntern[0]; ver[4] = verIntern[3]; ver[5] = verIntern[2];
            ver[6] = verIntern[0]; ver[7] = verIntern[1]; ver[8] = verIntern[5];
            ver[9] = verIntern[0]; ver[10] = verIntern[5]; ver[11] = verIntern[4];
            ver[12] = verIntern[0]; ver[13] = verIntern[4]; ver[14] = verIntern[6];
            ver[15] = verIntern[0]; ver[16] = verIntern[6]; ver[17] = verIntern[2];
            ver[18] = verIntern[1]; ver[19] = verIntern[7]; ver[20] = verIntern[5];
            ver[21] = verIntern[1]; ver[22] = verIntern[3]; ver[23] = verIntern[7];
            ver[24] = verIntern[3]; ver[25] = verIntern[2]; ver[26] = verIntern[6];
            ver[27] = verIntern[3]; ver[28] = verIntern[6]; ver[29] = verIntern[7];
            ver[30] = verIntern[4]; ver[31] = verIntern[5]; ver[32] = verIntern[7];
            ver[33] = verIntern[4]; ver[34] = verIntern[7]; ver[35] = verIntern[6];
        }
   
   }
}
