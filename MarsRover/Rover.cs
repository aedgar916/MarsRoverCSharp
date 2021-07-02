using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

        public void ReceiveMessage(Message message)
        {

            for(int i = 0; i < message.Commands.Length; i++)
            {
                string commandType = message.Commands[i].CommandType;

                if(commandType.Equals("MODE_CHANGE"))
                {
                    this.Mode = message.Commands[i].NewMode;
                }
                else if(commandType.Equals("MOVE"))
                {
                    if(this.Mode != "LOW_POWER")
                    {
                        this.Position = message.Commands[i].NewPostion;
                    }
                }
                else
                {
                    throw new Exception("Unknown Command. Message not sent.");
                }
            }
            return;
        }
    }
}
