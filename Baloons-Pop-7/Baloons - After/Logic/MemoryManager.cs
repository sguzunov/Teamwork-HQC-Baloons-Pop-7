namespace Balloons.Logic
{
    using System;
    using System.Collections.Generic;
    internal class MemoryManager
    {
        private Stack<Memory> saves = new Stack<Memory>();
        public Memory Memory { get; set; }

        public void SaveMemory()
        {
            saves.Push(this.Memory);
        }

        public Memory RestoreMemory()
        {          
            var restoreSave = saves.Pop();
            return restoreSave;
        }

        public void Clear()
        {
            saves.Clear();
        }
    }
}



