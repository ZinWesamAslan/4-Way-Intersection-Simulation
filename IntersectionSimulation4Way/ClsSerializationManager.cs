using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace IntersectionSimulation4Way
{
    public class ClsSerializationManager
    {
        private const string FilePath = "simulation_state.json";

        // حفظ الحالة في خيط خلفي
        public static async Task SaveStateAsync(ClsProjectState state)
        {
            await Task.Run(() =>
            {
                
                string json = JsonConvert.SerializeObject(state, Newtonsoft.Json.Formatting.Indented);

                
                File.WriteAllText(FilePath, json);
            });
        }

        // استعادة الحالة (الديسيريالايزيشن) تتم عادة في الخيط الأساسي قبل بدء المحاكاة
        public static ClsProjectState LoadState()
        {
            if (!File.Exists(FilePath)) return null;

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<ClsProjectState>(json);
        }
    }
}