using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.Model.Response
{
    public class QQInfo
    {
        /// <summary>
        /// QQ 号
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// QQ 昵称
        /// </summary>
        [JsonPropertyName("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// 性别，male 或 female 或 unknown
        /// </summary>
        [JsonPropertyName("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [JsonPropertyName("age")]
        public int Age { get; set; }

        /// <summary>
        /// QQ 等级
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        /// 等级加速度
        /// </summary>
        [JsonPropertyName("level_speed")]
        public double LevelSpeed { get; set; }

        /// <summary>
        /// 会员等级
        /// </summary>
        [JsonPropertyName("vip_level")]
        public string VipLevel { get; set; }

        /// <summary>
        /// 会员成长速度
        /// </summary>
        [JsonPropertyName("vip_growth_speed")]
        public int VipGrowthSpeed { get; set; }

        /// <summary>
        /// 会员成长总值
        /// </summary>
        [JsonPropertyName("vip_growth_total")]
        public int VipGrowthTotal { get; set; }
    }


}
