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

    class Test_Kamera{                                                                              


        /* First Person Kamera zum Testen ob das Level richtig spawnt. Funkitioniert zwar sehr schlecht aber dafür reichts.
         * Falls wir später noch eine zusätzliche First-Person Kamera machen wollen, muss diese hier noch massiv erweitert werden
        */

        public Vector3 cameraPosition;
        public float MoveSpeed, DrehSpeed;

        public GraphicsDevice device;

        public Matrix view, projection;

        Matrix rotation;

        float yaw = 0;
        float pitch = 0;

        int oldX, oldY;

        public Test_Kamera(Vector3 cameraPosition, float MoveSpeed, float DrehSpeed, GraphicsDevice device)
        {

            this.cameraPosition = cameraPosition;
            this.MoveSpeed = MoveSpeed;
            this.DrehSpeed = DrehSpeed;

            this.device = device;

            view = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), device.Viewport.AspectRatio, 0.1f, 1000.0f);

            resetMouseCursor();
        
        }

        public void Update() {

            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.W)) {
                Vector3 v = new Vector3(0, 0, -1) * MoveSpeed;
                move(v);
            }

            if(kState.IsKeyDown(Keys.S)){
                Vector3 v = new Vector3(0,0,1) * MoveSpeed;
                move(v);            
            }
                        if (kState.IsKeyDown(Keys.A)) {
                Vector3 v = new Vector3(-1, 0, 0) * MoveSpeed;
                move(v);
            }

            if(kState.IsKeyDown(Keys.D)){
                Vector3 v = new Vector3(1,0,0) * MoveSpeed;
                move(v);            
            }


            pitch = MathHelper.Clamp(pitch, -1.5f, 1.5f);

            MouseState mState = Mouse.GetState();

            int dx = mState.X - oldX;
            yaw -= DrehSpeed * dx;


            int dy = mState.Y - oldY;
            pitch -= DrehSpeed * dy;


            resetMouseCursor();


            UpdateMatrices();
        
            
        
        }

        private void resetMouseCursor() {

            int centerX = device.Viewport.Width / 2;
            int centerY = device.Viewport.Height / 2;

            Mouse.SetPosition(centerX, centerY);
            oldX = centerX;
            oldY = centerY;
        
        }

        private void UpdateMatrices() {
            rotation = Matrix.CreateRotationY(yaw) * Matrix.CreateRotationX(pitch);
            Vector3 transformedReference = Vector3.Transform(new Vector3(0, 0, -1), rotation);
            Vector3 lookAt = cameraPosition + transformedReference;

            view = Matrix.CreateLookAt(cameraPosition, lookAt, Vector3.Up);
        
        }

        private void move(Vector3 v){

            Matrix yRotation = Matrix.CreateRotationY(yaw);
            v = Vector3.Transform(v, yRotation);
            cameraPosition += v;
  
        }


    }
}
