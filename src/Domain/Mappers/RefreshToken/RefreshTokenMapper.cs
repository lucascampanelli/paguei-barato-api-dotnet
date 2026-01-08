using PagueiBaratoApi.Domain.Dtos.RefreshToken;

namespace PagueiBaratoApi.Domain.Mappers.RefreshToken;

public static class RefreshTokenMapper
{
    public static Entities.RefreshToken ToEntity(this RefreshTokenDto refreshTokenDto)
    {
        return new Entities.RefreshToken
        {
            Id = refreshTokenDto.Id,
            Token = refreshTokenDto.Token,
            Expiracao = refreshTokenDto.Expiracao,
            UsuarioId = refreshTokenDto.UsuarioId
        };
    }

    public static RefreshTokenDto ToDto(this Entities.RefreshToken refreshToken)
    {
        return new RefreshTokenDto
        {
            Id = refreshToken.Id,
            Token = refreshToken.Token,
            Expiracao = refreshToken.Expiracao,
            UsuarioId = refreshToken.UsuarioId
        };
    }
}
