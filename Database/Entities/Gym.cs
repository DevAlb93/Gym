namespace Database.Entities
{
    public class Gym
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        //NJe palester ka disa makineri
        public ICollection<Machine> Machines { get; set; }
    }
}
