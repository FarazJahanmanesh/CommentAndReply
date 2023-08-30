﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentAndReply.Core.Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
    public abstract class BaseEntity: BaseEntity<int>
    {
    }
}