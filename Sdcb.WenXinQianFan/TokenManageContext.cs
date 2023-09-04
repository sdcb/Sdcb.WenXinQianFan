using System;

namespace Sdcb.WenXinQianFan;

internal record TokenManageContext(AuthToken Token, DateTime GenerationTime)
{
    public bool IsValid => GenerationTime.AddSeconds(Token.ExpiresIn - 60) < DateTime.Now;
}
