using AikaEmu.GameServer.Controller;
using AikaEmu.GameServer.Managers;
using AikaEmu.GameServer.Models.Units.Npc.Const;
using AikaEmu.GameServer.Network.GameServer;
using AikaEmu.GameServer.Network.Packets.Game;
using AikaEmu.Shared.Network;

namespace AikaEmu.GameServer.Network.Packets.Client
{
    public class RequestNpcChat : GamePacket
    {
        protected override void Read(PacketStream stream)
        {
            var npcId = stream.ReadUInt32();
            var chatOption = (DialogType) stream.ReadUInt32();
            var subChatOption = stream.ReadUInt32();

            if (npcId == 0 && chatOption == DialogType.ChatClose)
                Connection.ActiveCharacter.SendPacket(new CloseNpcChat());
            NpcDialogController.StartDialog(Connection.ActiveCharacter, npcId, chatOption, subChatOption);
        }
    }
}