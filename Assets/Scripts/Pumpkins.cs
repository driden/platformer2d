namespace DefaultNamespace
{
    public static class Pumpkins
    {
        private static int _pumpkins;

        public static void AddPumpkin()
        {
            _pumpkins++;
        }
        
        public static int GetPumpkins()
        {
            return _pumpkins;
        }
        
        public static void ResetPumpkins()
        {
            _pumpkins++;
        }
    }
}