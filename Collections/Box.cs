namespace Collections

{
    public abstract class Box
    {
        [DescriptionField("Длина")]
        public uint Length { get; set; }
        [DescriptionField("Ширина")]
        public uint Width { get; set; }
        [DescriptionField("Высота")]
        public uint Hight { get; set; }
        [DescriptionField("Вес")]
        public uint Weight { get; set; }
        public abstract string AlarmMessage();
        public abstract string MessageaboutWeight();

    }
}

