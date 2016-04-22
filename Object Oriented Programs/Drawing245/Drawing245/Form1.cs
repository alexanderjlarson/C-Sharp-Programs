using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Drawing245
{
    public partial class Form1 : Form
    {
        Drawing drawing;
        Animator anim;
        bool inAnimationMode;
        bool inManualMode;
        public Form1()
        {
            drawing = new Drawing("Abstract Art", 20);
            anim = new Animator(5, 5);
            inAnimationMode = false;
            inManualMode = false;
            InitializeComponent();
        }

        private void panDrawing_MouseClick(object sender, MouseEventArgs e)
        {
            /* this event handler adds a shape to the drawing in response to the
             * user clicking somewhere. Which kind of shape it adds depends on
             * which radio button is currently checked. The location (x,y) is
             * set by e.X and e.Y.
             */
            if (!inAnimationMode && !inManualMode)
            {
                if (rbEllipse.Checked)
                {
                    drawing.AddShape(new Ellipse(e.X, e.Y, 100, 50));
                }
                else if (rbRectangle.Checked)
                {
                    drawing.AddShape(new Rectangle(e.X, e.Y, 50, 100));
                }
                else if (rbBall.Checked)
                {
                    drawing.AddShape(new Ball(e.X, e.Y, 30));
                }
            }
            panDrawing.Invalidate();

        }

        private void panDrawing_Paint(object sender, PaintEventArgs e)
        {
            Illustrator.Draw(drawing, panDrawing.CreateGraphics());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            drawing.Clear();
            panDrawing.Invalidate();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            drawing.UndoLast();
            panDrawing.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawing.UndoLast();
            panDrawing.Invalidate();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawing.Clear();
            panDrawing.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
                if (DrawingSerializer.SaveToBinary(drawing, dlgSaveFile.FileName, ref msg))
                {
                    MessageBox.Show("Your drawing was saved.");
                }
                else
                {
                    MessageBox.Show("Your drawing cound not be saved because this error happened: \n" + msg);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "";
            Drawing temp;
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                temp = DrawingSerializer.LoadFromBinary(dlgOpenFile.FileName, ref msg);
                if (temp == null)
                {
                    MessageBox.Show("Your drawing could not be loaded because this error happened:\n" + msg);
                }
                else
                {
                    drawing = temp;
                }
            }
            panDrawing.Invalidate();
        }

        private void btnAnimate_Click(object sender, EventArgs e)
        {
            inAnimationMode = !inAnimationMode;
            timer1.Enabled = inAnimationMode; //toggling the state of the timer
            if (inAnimationMode)
            {
                btnAnimate.Text = "Stop";
            }
            else
            {
                btnAnimate.Text = "Animate";
                drawing.ResetDisplacements();
                panDrawing.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //move the image somehow
            anim.MoveDrawingRandomly(drawing);
            panDrawing.Invalidate();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            inManualMode = !inManualMode;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (inManualMode)
            {
                if (e.KeyCode == Keys.Left)
                {
                    anim.MoveDrawingLeft(drawing);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    anim.MoveDrawingRight(drawing);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    anim.MoveDrawingUp(drawing);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    anim.MoveDrawingDown(drawing);
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool result;
            if (inManualMode)
            {
                if (keyData == Keys.Left)
                {
                    anim.MoveDrawingLeft(drawing);
                    result = true;
                }
                else if (keyData == Keys.Right)
                {
                    anim.MoveDrawingRight(drawing);
                    result = true;
                }
                else if (keyData == Keys.Up)
                {
                    anim.MoveDrawingUp(drawing);
                    result = true;
                }
                else if (keyData == Keys.Down)
                {
                    anim.MoveDrawingDown(drawing);
                    result = true;
                }
                else
                {
                    result = base.ProcessCmdKey(ref msg, keyData);
                }
            }
            else
            {
                result = base.ProcessCmdKey(ref msg, keyData);
            }
            panDrawing.Invalidate();
            return result;
        }
    }
}
