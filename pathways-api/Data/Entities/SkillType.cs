﻿namespace pathways_api.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using pathways_common.Entities;

    /// <summary>
    /// Abstracting, etc...
    /// </summary>
    [Table("skilltype", Schema = "skills")]
    public class SkillType : DescriptionEntity
    {
    }
}