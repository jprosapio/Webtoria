using System;
using System.Collections.Generic;
using System.Text;

namespace Webtoria
{
    class Pop
    {
        public int job;

        public Pop (int jobID = -1)
        {
            this.job = jobID;
        }

        public void setJob(int jobID)
        {
            this.job = jobID;
        }
    }
}
