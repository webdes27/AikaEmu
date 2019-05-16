using AikaEmu.GameServer.Helpers;
using AikaEmu.GameServer.Network.GameServer;
using AikaEmu.Shared.Network;

namespace AikaEmu.GameServer.Network.Packets.Client
{
    public class ChangePartyLeader : GamePacket
    {
        protected override void Read(PacketStream stream)
        {
            var conId = stream.ReadUInt16();

            GroupHelper.PartyChangeLeader(Connection, conId);
        }
    }
}