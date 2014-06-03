using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyTrack
{
    class Matrix
    {
        readonly float[] mat;

        public Matrix(float[] values)
        {
            mat = new[] { values[0], values[1], values[2], 
                          values[3], values[4], values[5], 
                          values[6], values[7], values[8] };
        }

        public override string ToString()
        {
            return "[" + mat[0] + " " + mat[1] + " " + mat[2] + " " + mat[3] + " " + mat[4] + " " + mat[5] + " " + mat[6] + " " + mat[7] + " " + mat[8] + "]";
        }
    }
}
